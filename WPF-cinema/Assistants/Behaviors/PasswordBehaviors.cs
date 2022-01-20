﻿using Microsoft.Xaml.Behaviors;
using System.Windows;
using System.Windows.Controls;

namespace WPF_cinema.Assistants.Behaviors
{
    class PasswordBehaviors : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.Register("Password", typeof(string), typeof(PasswordBehaviors), new PropertyMetadata(default(string)));

        private bool _skipUpdate;

        public string Password
        {
            get { return (string)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        protected override void OnAttached()
        {
            AssociatedObject.PasswordChanged += PasswordBox_PasswordChanged;
        }

        protected override void OnDetaching()
        {
            AssociatedObject.PasswordChanged -= PasswordBox_PasswordChanged;
        }

        protected override void OnPropertyChanged(DependencyPropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);

            if (e.Property == PasswordProperty)
            {
                if (!_skipUpdate)
                {
                    _skipUpdate = true;
                    AssociatedObject.Password = e.NewValue as string;
                    _skipUpdate = false;
                }
            }
        }

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            _skipUpdate = true;
            Password = AssociatedObject.Password;
            _skipUpdate = false;
        }
    }
}

