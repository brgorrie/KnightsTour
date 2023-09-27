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
using KnightsTour;
using KnightsTour.Models;
using KnightsTour.Services;
using KnightsTour.Utilities;

public class Program
{
    public static void Main(string[] args)
    {
        var containerBuilder = new ContainerBuilder();

        var n = int.Parse(args[0]);
        var unique = bool.Parse(args[1]);
        var useWarnsdorff = bool.Parse(args[2]);

        containerBuilder.RegisterType<ChessBoard>()
            .WithParameter("n", n)
            .As<IChessBoard>();

        containerBuilder.RegisterType<KnightsTourService>().As<IKnightsTourService>();

        if (useWarnsdorff)
            containerBuilder.RegisterType<WarnsdorffTourSolver>().As<ITourSolver>();
        else
            containerBuilder.RegisterType<SimpleTourSolver>().As<ITourSolver>();

        containerBuilder.RegisterType<KnightsTourRunner>();

        var container = containerBuilder.Build();

        using (var scope = container.BeginLifetimeScope())
        {
            var runner = scope.Resolve<KnightsTourRunner>();
            runner.Run(n, unique, useWarnsdorff);
        }
    }

}
