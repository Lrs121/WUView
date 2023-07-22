﻿// Copyright (c) Tim Kennedy. All Rights Reserved. Licensed under the MIT License.

namespace WUView.Configuration;

/// <summary>
/// Class to handle certain changes in user settings.
/// </summary>
public static class SettingChange
{
    #region Private fields
    private static readonly Logger _log = LogManager.GetLogger("logTemp");
    #endregion Private fields

    #region Setting change
    /// <summary>
    /// Handle changes in UserSettings
    /// </summary>
    public static void UserSettingChanged(object sender, PropertyChangedEventArgs e)
    {
        object newValue = MainWindowHelpers.GetPropertyValue(sender, e);
        _log.Debug($"Setting change: {e.PropertyName} New Value: {newValue}");

        switch (e.PropertyName)
        {
            case nameof(UserSettings.Setting.IncludeDebug):
                NLogHelpers.SetLogLevel((bool)newValue);
                break;

            case nameof(UserSettings.Setting.UITheme):
                MainWindowUIHelpers.SetBaseTheme((ThemeType)newValue);
                break;

            case nameof(UserSettings.Setting.PrimaryColor):
                MainWindowUIHelpers.SetPrimaryColor((AccentColor)newValue);
                break;

            case nameof(UserSettings.Setting.UISize):
                MainWindowUIHelpers.UIScale(UserSettings.Setting.UISize);
                break;

            case nameof(UserSettings.Setting.ShowDetails):
                MainWindowUIHelpers.ToggleDetails((bool)newValue);
                break;

            case nameof(UserSettings.Setting.MaxUpdates):
                MainPage.RefreshAll();
                break;

            case nameof(UserSettings.Setting.ExcludeKBandResult):
                MainPage.RefreshAll();
                break;
        }
    }

    /// <summary>
    /// Handle changes in TempSettings
    /// </summary>
    internal static void TempSettingChanged(object sender, PropertyChangedEventArgs e)
    {
        object newValue = MainWindowHelpers.GetPropertyValue(sender, e);
        // Write to trace level to avoid unnecessary message in log file
        _log.Trace($"Temp Setting change: {e.PropertyName} New Value: {newValue}");
    }
    #endregion Setting change
}
