﻿/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocatorTemplate xmlns:vm="clr-namespace:Twinder.ViewModel"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using Twinder.Design;
using Twinder.Model;
using Twinder.ViewModel.Design;

namespace Twinder.ViewModel
{
	/// <summary>
	/// This class contains static references to all the view models in the
	/// application and provides an entry point for the bindings.
	/// <para>
	/// See http://www.mvvmlight.net
	/// </para>
	/// </summary>
	public class ViewModelLocator
	{
		static ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			if (ViewModelBase.IsInDesignModeStatic)
			{
				SimpleIoc.Default.Register<IDataService, DesignDataService>();
			}

			SimpleIoc.Default.Register<MainViewModel>();
			SimpleIoc.Default.Register<FbLoginViewModel>();
			SimpleIoc.Default.Register<ChatViewModel>();
			SimpleIoc.Default.Register<MatchProfileViewModel>();
			SimpleIoc.Default.Register<RecommendationsViewModel>();
			SimpleIoc.Default.Register<SetLocationViewModel>();

			// Design time
			SimpleIoc.Default.Register<SampleMainVM>();
		}

		/// <summary>
		/// Gets the Main property.
		/// </summary>
		[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
			"CA1822:MarkMembersAsStatic",
			Justification = "This non-static member is needed for data binding purposes.")]
		public MainViewModel Main
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MainViewModel>();
			}
		}

		public FbLoginViewModel SetUser
		{
			get
			{
				return ServiceLocator.Current.GetInstance<FbLoginViewModel>();
			}
		}

		public ChatViewModel Chat
		{
			get
			{
				return ServiceLocator.Current.GetInstance<ChatViewModel>();
			}
		}

		public MatchProfileViewModel MatchProfile
		{
			get
			{
				return ServiceLocator.Current.GetInstance<MatchProfileViewModel>();
			}
		}

		public RecommendationsViewModel Recommendations
		{
			get
			{
				return ServiceLocator.Current.GetInstance<RecommendationsViewModel>();
			}
		}

		public SetLocationViewModel SetLocation
		{
			get
			{
				return ServiceLocator.Current.GetInstance<SetLocationViewModel>();
			}
		}



		// Design time
		public SampleMainVM SampleMain
		{
			get
			{
				return ServiceLocator.Current.GetInstance<SampleMainVM>();
			}
		}

		/// <summary>
		/// Cleans up all the resources.
		/// </summary>
		public static void Cleanup()
		{
		}
	}
}