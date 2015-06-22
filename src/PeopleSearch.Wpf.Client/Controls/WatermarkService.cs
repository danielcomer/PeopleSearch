using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using PeopleSearch.Wpf.Client.Adorners;

namespace PeopleSearch.Wpf.Client.Controls
{
    /// <summary>
    /// Class that provides the Watermark attached property
    /// </summary>
    public class WatermarkService
    {
        #region Fields

        /// <summary>
        /// Dictionary of ItemsControls
        /// </summary>
        private static readonly Dictionary<object, ItemsControl> ItemsControls = new Dictionary<object, ItemsControl>();

        #endregion Fields

        #region Dependency Properties

        /// <summary>
        /// Watermark Attached Dependency Property
        /// </summary>
        public static readonly DependencyProperty WatermarkProperty = 
            DependencyProperty.RegisterAttached(
                "Watermark",
                typeof (object),
                typeof (WatermarkService),
                new FrameworkPropertyMetadata(null, HandleWatermarkChanged));

        #endregion Dependency Properties

        #region Handlers

        /// <summary>
        /// Handles changes to the Watermark property.
        /// </summary>
        /// <param name="sender"><see cref="DependencyObject"/> that fired the event</param>
        /// <param name="args">A <see cref="DependencyPropertyChangedEventArgs"/> that contains the event data.</param>
        private static void HandleWatermarkChanged(DependencyObject sender, DependencyPropertyChangedEventArgs args)
        {
            var control = (Control)sender;
            control.Loaded += HandleControlLoaded;

            if (sender is TextBox || sender is PasswordBox)
            {
                control.GotKeyboardFocus += HandleControlGotKeyboardFocus;
                control.LostKeyboardFocus += HandleControlLoaded;
            }
            else if (sender is ComboBox)
            {
                control.GotKeyboardFocus += HandleControlGotKeyboardFocus;
                control.LostKeyboardFocus += HandleControlLoaded;
                (sender as ComboBox).SelectionChanged += HandleSelectionChanged;
            }
            else if (sender is ItemsControl)
            {
                var i = (ItemsControl)sender;

                i.ItemContainerGenerator.ItemsChanged += HandleItemsChanged;
                ItemsControls.Add(i.ItemContainerGenerator, i);

                var prop = DependencyPropertyDescriptor.FromProperty(ItemsControl.ItemsSourceProperty, i.GetType());
                prop.AddValueChanged(i, HandleItemsSourceChanged);
            }
        }

        /// <summary>
        /// Event handler for the selection changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">A <see cref="ItemsChangedEventArgs"/> that contains the event data.</param>
        private static void HandleSelectionChanged(object sender, SelectionChangedEventArgs args)
        {
            var control = (Control)sender;
            if (ShouldShowWatermark(control))
            {
                ShowWatermark(control);
            }
            else
            {
                RemoveWatermark(control);
            }
        }

        /// <summary>
        /// Handle the GotFocus event on the control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">A <see cref="RoutedEventArgs"/> that contains the event data.</param>
        private static void HandleControlGotKeyboardFocus(object sender, RoutedEventArgs args)
        {
            var c = (Control)sender;
            if (ShouldShowWatermark(c))
            {
                RemoveWatermark(c);
            }
        }

        /// <summary>
        /// Handle the Loaded and LostFocus event on the control
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">A <see cref="RoutedEventArgs"/> that contains the event data.</param>
        private static void HandleControlLoaded(object sender, RoutedEventArgs args)
        {
            var control = (Control)sender;
            if (ShouldShowWatermark(control))
            {
                ShowWatermark(control);
            }
        }

        /// <summary>
        /// Event handler for the items source changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">A <see cref="EventArgs"/> that contains the event data.</param>
        private static void HandleItemsSourceChanged(object sender, EventArgs args)
        {
            var c = (ItemsControl)sender;
            if (c.ItemsSource != null)
            {
                if (ShouldShowWatermark(c))
                {
                    ShowWatermark(c);
                }
                else
                {
                    RemoveWatermark(c);
                }
            }
            else
            {
                ShowWatermark(c);
            }
        }

        /// <summary>
        /// Event handler for the items changed event
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">A <see cref="ItemsChangedEventArgs"/> that contains the event data.</param>
        private static void HandleItemsChanged(object sender, ItemsChangedEventArgs args)
        {
            ItemsControl control;

            if (!ItemsControls.TryGetValue(sender, out control)) return;

            if (ShouldShowWatermark(control))
            {
                ShowWatermark(control);
            }
            else
            {
                RemoveWatermark(control);
            }
        }

        #endregion Handlers

        #region Methods

        #region Public

        /// <summary>
        /// Gets the Watermark property.  This dependency property indicates the watermark for the control.
        /// </summary>
        /// <param name="d"><see cref="DependencyObject"/> to get the property from</param>
        /// <returns>The value of the Watermark property</returns>
        public static object GetWatermark(DependencyObject d)
        {
            return d.GetValue(WatermarkProperty);
        }

        /// <summary>
        /// Sets the Watermark property.  This dependency property indicates the watermark for the control.
        /// </summary>
        /// <param name="sender"><see cref="DependencyObject"/> to set the property on</param>
        /// <param name="value">value of the property</param>
        public static void SetWatermark(DependencyObject sender, object value)
        {
            sender.SetValue(WatermarkProperty, value);
        }

        #endregion Public

        #region Private

        /// <summary>
        /// Remove the watermark from the specified element
        /// </summary>
        /// <param name="element">Element to remove the watermark from</param>
        private static void RemoveWatermark(UIElement element)
        {
            var layer = AdornerLayer.GetAdornerLayer(element);

            // layer could be null if control is no longer in the visual tree
            var adorners = layer?.GetAdorners(element);

            if (adorners == null) return;

            foreach (var adorner in adorners.OfType<WatermarkAdorner>())
            {
                adorner.Visibility = Visibility.Hidden;
                layer.Remove(adorner);
            }
        }

        /// <summary>
        /// Show the watermark on the specified control
        /// </summary>
        /// <param name="element">Control to show the watermark on</param>
        private static void ShowWatermark(UIElement element)
        {
            var layer = AdornerLayer.GetAdornerLayer(element);

            // layer could be null if control is no longer in the visual tree
            layer?.Add(new WatermarkAdorner(element, GetWatermark(element)));
        }

        /// <summary>
        /// Indicates whether or not the watermark should be shown on the specified control
        /// </summary>
        /// <param name="control"><see cref="Control"/> to test</param>
        /// <returns>true if the watermark should be shown; false otherwise</returns>
        private static bool ShouldShowWatermark(Control control)
        {
            if (control is ComboBox)
            {
                return ((ComboBox)control).SelectedItem == null;
            }
            if (control is TextBoxBase)
            {
                var textBox = control as TextBox;
                return textBox != null && textBox.Text == string.Empty;
            }
            if (control is PasswordBox)
            {
                return ((PasswordBox)control).Password == string.Empty;
            }

            return (control as ItemsControl)?.Items.Count == 0;
        }

        #endregion Private

        #endregion Methods
    }
}
