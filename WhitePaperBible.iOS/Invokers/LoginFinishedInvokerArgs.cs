﻿using System;
using MonkeyArms;
using MonoTouch.UIKit;

namespace WhitePaperBible.iOS.Invokers
{
	public class LoginFinishedInvokerArgs: InvokerArgs
	{
		public UIViewController Controller;

		public LoginFinishedInvokerArgs(UIViewController controller)
		{
			this.Controller = controller;
		}
	}
}

