using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Win32;

namespace DisableWebcamLights
{
	internal class WebcamLights
	{
		public static void Disable()
		{
			try
			{
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{6BDD1FC6-810F-11D0-BEC7-08002BE2092F}"))
				{
					foreach (string item in from x in registryKey.GetSubKeyNames()
						where Regex.IsMatch(x, "[0-9]{4}")
						select x)
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(item))
						{
							registryKey2.SetValue("", 8, RegistryValueKind.DWord);
						}
					}
				}
			}
			catch (Exception)
			{
			}
			try
			{
				using (RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}"))
				{
					foreach (string item2 in from x in registryKey3.GetSubKeyNames()
						where Regex.IsMatch(x, "[0-9]{4}")
						select x)
					{
						using (RegistryKey registryKey4 = registryKey3.OpenSubKey(item2))
						{
							registryKey4.SetValue("LedMode", 1, RegistryValueKind.DWord);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}

		public static void Enable()
		{
			try
			{
				using (RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{6BDD1FC6-810F-11D0-BEC7-08002BE2092F}"))
				{
					foreach (string item in from x in registryKey.GetSubKeyNames()
						where Regex.IsMatch(x, "[0-9]{4}")
						select x)
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(item))
						{
							registryKey2.SetValue("", 0, RegistryValueKind.DWord);
						}
					}
				}
			}
			catch (Exception)
			{
			}
			try
			{
				using (RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Class\\{4D36E972-E325-11CE-BFC1-08002BE10318}"))
				{
					foreach (string item2 in from x in registryKey3.GetSubKeyNames()
						where Regex.IsMatch(x, "[0-9]{4}")
						select x)
					{
						using (RegistryKey registryKey4 = registryKey3.OpenSubKey(item2))
						{
							registryKey4.SetValue("LedMode", 0, RegistryValueKind.DWord);
						}
					}
				}
			}
			catch (Exception)
			{
			}
		}
	}
}
