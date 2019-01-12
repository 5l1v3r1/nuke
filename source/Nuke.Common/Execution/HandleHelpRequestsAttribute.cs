// Copyright 2019 Maintainers of NUKE.
// Distributed under the MIT License.
// https://github.com/nuke-build/nuke/blob/master/LICENSE

using System;
using System.Linq;

namespace Nuke.Common.Execution
{
    [AttributeUsage(AttributeTargets.Class)]
    internal class HandleHelpRequestsAttribute : Attribute, IPostLogoBuildExtension
    {
        public void Execute<T>(NukeBuild<T> build)
        {
            if (NukeBuild.Help)
            {
                Logger.Log(HelpTextService.GetTargetsText(build.ExecutableTargets));
                Logger.Log(HelpTextService.GetParametersText(build, build.ExecutableTargets));
            }

            if (NukeBuild.Plan)
                ExecutionPlanHtmlService.ShowPlan(build.ExecutableTargets);

            if (NukeBuild.Help || NukeBuild.Plan)
                Environment.Exit(exitCode: 0);
        }
    }
}
