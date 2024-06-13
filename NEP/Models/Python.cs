using System.Diagnostics;
using System;
namespace NEP.Models
{
    public class Python
    {

        public string SendCode(string phoneNumber)
        {
            string status = string.Empty;
            // Create a new process instance
            Process process = new Process();

            try
            {
                // Configure the process start info
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "python"; // or the full path to the python executable
                startInfo.Arguments = "../Telnyx.py"; // replace with the path to your Python script
                startInfo.RedirectStandardOutput = true;
                startInfo.UseShellExecute = false;
                startInfo.CreateNoWindow = true;

                // Start the process
                process.StartInfo = startInfo;
                process.Start();

                // Read the output from the Python script
                string output = process.StandardOutput.ReadToEnd();
                status = output;
                //Console.WriteLine(output);
            }
            finally
            {
                // Ensure the process is closed
                process.Close();
                status = process.StandardError.ReadToEnd();
                
            }
            return status;
        }
    }

}
