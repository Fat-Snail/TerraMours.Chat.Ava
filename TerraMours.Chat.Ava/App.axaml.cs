using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.DependencyInjection;
using Splat;
using System;
using TerraMours.Chat.Ava.Models;
using TerraMours.Chat.Ava.ViewModels;
using TerraMours.Chat.Ava.Views;

namespace TerraMours.Chat.Ava {
    public partial class App : Application {
        public override void Initialize() {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted() {
            //��ӹ�����Դ
            var VMLocator = new VMLocator();
            Resources.Add("VMLocator", VMLocator);

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop) {
                var load = new LoadView {
                    DataContext = new LoadViewModel(),
                };
                desktop.MainWindow = load;
                VMLocator.LoadViewModel.ToMainAction = () =>
                {
                    desktop.MainWindow = new MainWindow();
                    desktop.MainWindow.Show();
                    load.Close();
                };

            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}