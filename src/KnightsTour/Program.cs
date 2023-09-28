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

public class Program
{
    public static void Main(string[] args)
    {
        var parserResult = Parser.Default.ParseArguments<Options>(args);
        parserResult.WithParsed(options =>
        {
            RunWithOptions(options);
        });
    }

    public static void RunWithOptions(Options options)
    {
        var containerBuilder = new ContainerBuilder();
        containerBuilder.RegisterType<ChessBoard>()
            .WithParameter("n", options.BoardSize)
            .As<IChessBoard>();

        containerBuilder.RegisterType<KnightsTourService>().As<IKnightsTourService>();
        containerBuilder.RegisterType<ConsoleOutputService>().As<IOutputService>();

        if (options.UseWarnsdorff)
            containerBuilder.RegisterType<WarnsdorffTourSolver>().As<ITourSolver>();
        else
            containerBuilder.RegisterType<SimpleTourSolver>().As<ITourSolver>();

        containerBuilder.RegisterType<KnightsTourRunner>().As<IKnightsTourRunner>();

        var container = containerBuilder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            var runner = scope.Resolve<IKnightsTourRunner>();
            runner.Run(options.BoardSize, options.Unique, options.UseWarnsdorff);
        }
    }

}
