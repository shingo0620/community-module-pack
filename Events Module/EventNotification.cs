using Blish_HUD;
using Blish_HUD.Content;
using Blish_HUD.Controls;
using Events_Module.Properties;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Events_Module {
    public class EventNotification : Container {

        private const int NOTIFICATION_WIDTH = 300;
        private const int NOTIFICATION_HEIGHT = 84;
        private const int ICON_COLUMN_WIDTH = 68;

        #region Load Static

        private static readonly Texture2D _textureBackground;

        static EventNotification() {
            _textureBackground = EventsModule.ModuleInstance.ContentsManager.GetTexture(@"textures\ns-button.png");
        }

        #endregion

        private readonly AsyncTexture2D _icon;

        private static int _visibleNotifications = 0;

        private EventNotification(string title, AsyncTexture2D icon, string message, string waypoint) {
            string tooltipText = EventsModule.GetLocalizedString("Notification_Tooltip");

            _icon = icon;

            this.Opacity          = 0f;
            this.Size             = new Point(NOTIFICATION_WIDTH, NOTIFICATION_HEIGHT);
            this.Location         = new Point(EventsModule.ModuleInstance.NotificationPosition.X, EventsModule.ModuleInstance.NotificationPosition.Y + (NOTIFICATION_HEIGHT + 15) * _visibleNotifications);
            this.BasicTooltipText = tooltipText;

            int textWidth = this.Width - ICON_COLUMN_WIDTH - 16;
            string wrappedTitle = DrawUtil.WrapText(Content.DefaultFont14, title, textWidth);

            new Label() {
                Parent           = this,
                Location         = new Point(ICON_COLUMN_WIDTH + 8, 7),
                Size             = new Point(textWidth, 46),
                Font             = Content.DefaultFont14,
                BasicTooltipText = tooltipText,
                Text             = wrappedTitle,
                WrapText         = true,
            };

            string wrappedMessage = DrawUtil.WrapText(Content.DefaultFont14, message, textWidth);

            new Label() {
                Parent           = this,
                Location         = new Point(ICON_COLUMN_WIDTH + 8, 57),
                Size             = new Point(textWidth, 22),
                BasicTooltipText = tooltipText,
                Text             = wrappedMessage,
                WrapText         = true,
            };

            _visibleNotifications++;

            this.RightMouseButtonReleased += delegate { this.Dispose(); };
            this.LeftMouseButtonReleased += delegate {
                ClipboardUtil.WindowsClipboardService.SetTextAsync(waypoint)
                             .ContinueWith((clipboardResult) => {
                                  if (clipboardResult.IsFaulted) {
                                      ScreenNotification.ShowNotification(Resources.Failed_to_copy_waypoint_to_clipboard__Try_again_, ScreenNotification.NotificationType.Red, duration: 2);
                                  } else {
                                      ScreenNotification.ShowNotification(Resources.Copied_waypoint_to_clipboard_, duration: 2);
                                  }
                              });

                this.Dispose();
            };
        }

        protected override CaptureType CapturesInput() {
            return CaptureType.Mouse;
        }

        private Rectangle _layoutIconBounds;

        public override void RecalculateLayout() {
            int icoSize = 52;

            _layoutIconBounds = new Rectangle(ICON_COLUMN_WIDTH / 2 - icoSize / 2,
                                              NOTIFICATION_HEIGHT / 2 - icoSize / 2,
                                              icoSize,
                                              icoSize);
        }

        public override void PaintBeforeChildren(SpriteBatch spriteBatch, Rectangle bounds) {
            spriteBatch.DrawOnCtrl(this,
                                   _textureBackground,
                                   bounds,
                                   Color.White * 0.85f);

            if (_icon != null) {
                spriteBatch.DrawOnCtrl(this,
                                       _icon,
                                       _layoutIconBounds);
            }
        }

        private void Show(float duration) {
            if (EventsModule.ModuleInstance.ChimeEnabled) {
                Content.PlaySoundEffectByName(@"audio\color-change");
            }

            Animation.Tweener
                     .Tween(this, new { Opacity = 1f }, 0.2f)
                     .Repeat(1)
                     .RepeatDelay(duration)
                     .Reflect()
                     .OnComplete(Dispose);
        }

        public static void ShowNotification(string title, AsyncTexture2D icon, string message, float duration, string waypoint) {
            var notif = new EventNotification(title, icon, message, waypoint) {
                Parent = Graphics.SpriteScreen
            };

            notif.Show(duration);
        }

        protected override void DisposeControl() {
            _visibleNotifications--;

            base.DisposeControl();
        }

    }
}
