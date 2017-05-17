#load "dep1.csx"
#load "run.csx"

using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

// cmd /c "C:\Program Files (x86)\Microsoft Visual Studio\2017\Enterprise\MSBuild\15.0\Bin\Roslyn\csi.exe" .\TestFunction\test.csx
var z = new Adder().Add(2, 2);
Console.WriteLine($"{z}");