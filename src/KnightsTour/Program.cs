// Copyright 2023 Brian Gorrie
//
// Licensed under the Apache License, Version 2.0 (the "License")
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using Autofac;
using CommandLine;
using KnightsTour;
using KnightsTour.Models;
using KnightsTour.Services;
using KnightsTour.Utilities;

/// <summary>
/// Entry point for the application which solves the Knight's Tour problem.
/// </summary>
public class Program
{
    /// <summary>
    /// The main entry point for the application. It initializes the application with user-defined options.
    /// </summary>
    /// <param name="args">The command-line arguments.</param>
    public static void Main(string[] args)
    {
        // Parse the command-line arguments to map them to the defined options.
        var parserResult = Parser.Default.ParseArguments<Options>(args);

        // Execute the RunWithOptions method with the parsed options.
        parserResult.WithParsed(options =>
        {
            RunWithOptions(options);
        });
    }

    /// <summary>
    /// Configures and runs the application with the specified options.
    /// </summary>
    /// <param name="options">The user-defined options influencing the execution of the Knight's Tour algorithm.</param>
    public static void RunWithOptions(Options options)
    {
        // Initialize a ContainerBuilder to register the dependencies.
        var containerBuilder = new ContainerBuilder();

        // Register the dependencies with the required parameters.
        containerBuilder.RegisterType<ChessBoard>()
            .WithParameter("n", options.BoardSize)
            .As<IChessBoard>();

        containerBuilder.RegisterType<KnightsTourService>().As<IKnightsTourService>();
        containerBuilder.RegisterType<ConsoleOutputService>().As<IOutputService>();

        // Decide the solver type based on the user preference
        if (options.UseWarnsdorff)
            containerBuilder.RegisterType<WarnsdorffTourSolver>().As<ITourSolver>();
        else
            containerBuilder.RegisterType<SimpleTourSolver>().As<ITourSolver>();

        containerBuilder.RegisterType<KnightsTourRunner>().As<IKnightsTourRunner>();

        // Build the container and begin the scope.
        var container = containerBuilder.Build();
        using (var scope = container.BeginLifetimeScope())
        {
            // Resolve the runner and start running with the provided options.
            var runner = scope.Resolve<IKnightsTourRunner>();
            runner.Run(options.BoardSize, options.Unique);
        }

    }

}
