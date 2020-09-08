using System.CodeDom.Compiler;
using System.Diagnostics;
using global::Microsoft.VisualStudio.TestTools.UnitTesting;
using global::TechTalk.SpecFlow;

[GeneratedCode("SpecFlow", "3.1.97")]
[TestClass]
public class Reqres_Automation_Framework_MSTestAssemblyHooks
{
    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext)
    {
        var currentAssembly = typeof(Reqres_Automation_Framework_MSTestAssemblyHooks).Assembly;

        TestRunnerManager.OnTestRunStart(currentAssembly);
    }

    [AssemblyCleanup]
    public static void AssemblyCleanup()
    {
        var currentAssembly = typeof(Reqres_Automation_Framework_MSTestAssemblyHooks).Assembly;

        TestRunnerManager.OnTestRunEnd(currentAssembly);
    }
}
