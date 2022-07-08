using System;
using System.Threading;
using System.IO;
using System.Security.Principal;
using System.Windows;
using System.Linq;

namespace CloaksPlus
{
    class Program
    {
        private static EbicConsoleStuff console = new EbicConsoleStuff();
        
        static void Main(string[] args)
        {
            Console.Title = "Cloaks+ Installer";
            Console.ForegroundColor = ConsoleColor.Blue;
            Program.console.smoothWrite("   ___ _             _              \n  / __\\ | ___   __ _| | _____   _   \n / /  | |/ _ \\ / _` | |/ / __|_| |_ \n/ /___| | (_) | (_| |   <\\__ \\_   _|\n\\____/|_|\\___/ \\__,_|_|\\_\\___/ |_|  \n                                    \n");
            Console.ForegroundColor = ConsoleColor.White;
            Program.console.smoothWrite("Please type one of the following options below:");
            Program.console.smoothWrite("[install] Install Cloaks+ onto your device.");
            Program.console.smoothWrite("[uninstall] Remove Cloaks+ from your device.");
            Console.ForegroundColor = ConsoleColor.Gray;
            string installOrUninstall = Console.ReadLine();
            if (installOrUninstall.Equals("install", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Program.console.smoothWrite("Attempting to install Cloaks+...");
                Thread.Sleep(50);
                Program.console.smoothWrite("Checking if the installer is ran with administrator priviliges...");
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Program.console.smoothWrite("The Cloaks+ installer must be ran with administrator priviliges! Closing in 5 seconds...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Program.console.smoothWrite("Administrator priviliges detected! Attempting to install Cloaks+...");
                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    try
                    {
                        string contents = File.ReadAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts"));
                        if (contents.Contains("161.35.130.99 s.optifine.net"))
                        {
                            MessageBox.Show("You already have Cloaks+ installed!", "Cloaks+", MessageBoxButton.OK, MessageBoxImage.Hand);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Program.console.smoothWrite("It looks like you already have Cloaks+ installed! Closing in 5 seconds...");
                            Thread.Sleep(5000);
                            Environment.Exit(0);
                        }
                        else
                        {
                            using (StreamWriter hosts = File.AppendText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts")))
                            {
                                Console.ForegroundColor = ConsoleColor.Gray;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Program.console.smoothWrite("Installing Cloaks+");
                                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
                                var deleteOptifineShit = "s.optifine.net";
                                var oldLines = File.ReadAllLines(path);
                                var newLines = oldLines.Where(line => !line.Contains(deleteOptifineShit));
                                File.WriteAllLines(path, newLines);
                                hosts.WriteLine("\n161.35.130.99 s.optifine.net # Line inserted by Cloaks+.");
                                Thread.Sleep(500);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Green;
                                Program.console.smoothWrite("Cloaks+ has successfully been installed!");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Program.console.smoothWrite("Closing in 5 seconds...");
                                Thread.Sleep(5000);
                                Environment.Exit(0);
                            }
                        }
                    }
                    catch (IOException a)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Program.console.smoothWrite("An error occured while installing Cloaks!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error:" + a.Message);
                        Thread.Sleep(5000);
                    }
                    catch (Exception efe)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Program.console.smoothWrite("An error occured while installing Cloaks!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error:" + efe.Message);
                        Thread.Sleep(5000);
                    }
                }
                
            }
            else if (installOrUninstall.Equals("uninstall", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Green;
                Program.console.smoothWrite("We are sad to see you go!\nAttempting to uninstall Cloaks+...");
                Program.console.smoothWrite("Checking if the installer is ran with administrator priviliges...");
                WindowsIdentity identity = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(identity);
                if (!principal.IsInRole(WindowsBuiltInRole.Administrator))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.DarkGray;
                    Program.console.smoothWrite("The Cloaks+ installer must be ran with administrator priviliges! Closing in 5 seconds...");
                    Thread.Sleep(5000);
                    Environment.Exit(0);
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Program.console.smoothWrite("Administrator priviliges detected! Attempting to install Cloaks+...");
                    Thread.Sleep(300);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    try
                    {
                        string contents = File.ReadAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts"));
                        if (contents.Contains("161.35.130.99 s.optifine.net"))
                        {
                            Program.console.smoothWrite("Successfully detected Cloaks+ on your device! Attempting to uninstall...");
                            Thread.Sleep(500);
                            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
                            var deleteOptifineShit = "s.optifine.net";
                            var oldLines = File.ReadAllLines(path);
                            var newLines = oldLines.Where(line => !line.Contains(deleteOptifineShit));
                            File.WriteAllLines(path, newLines);
                            var fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.System), "drivers/etc/hosts");
                            File.WriteAllLines(fileName, File.ReadLines(fileName).Where(l => l != "161.35.130.99 s.optifine.net").ToList());
                            Program.console.smoothWrite("Cloaks+ has successfully been uninstalled.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.BackgroundColor = ConsoleColor.Black;
                                Program.console.smoothWrite("Closing in 5 seconds...");
                                Thread.Sleep(5000);
                                Environment.Exit(0);
                        }
                        else
                        {
                            MessageBox.Show("You do not have Cloaks+ installed, there is nothing to remove!", "Cloaks+", MessageBoxButton.OK, MessageBoxImage.Hand);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.BackgroundColor = ConsoleColor.Black;
                            Program.console.smoothWrite("It looks like you already have Cloaks+ installed! Closing in 5 seconds...");
                            Thread.Sleep(5000);
                            Environment.Exit(0);
                        }
                    }
                    catch (IOException ioexcp)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Program.console.smoothWrite("An error occured while installing Cloaks!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error:" + ioexcp.Message);
                        Thread.Sleep(5000);
                    }
                    catch (Exception excpnn)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Program.console.smoothWrite("An error occured while installing Cloaks!");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error:" + excpnn.Message);
                        Thread.Sleep(5000);
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Program.console.smoothWrite("You did not choose a valid option! Please choose between \"install\" and \"uninstall\". Closing in 5 seconds...");
                Thread.Sleep(5000);
                Environment.Exit(0);
            }
        }
    }
}
