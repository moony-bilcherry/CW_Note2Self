using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Note2Self.ValueConverters
{
    public class EnumToEmojiMoodConverter : BaseValueConverter<EnumToEmojiMoodConverter>
    {
        public (PossibleMoods mood, string emoji)[] MoodEmojis = new[]
        {
            (PossibleMoods.Calm, "🙂"),
            (PossibleMoods.Anxious, "🥴"),
            (PossibleMoods.Happy, "😊"),
            (PossibleMoods.Sad, "😥"),
            (PossibleMoods.Tired, "😴")
        };

        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MoodEmojis.FirstOrDefault(el => el.mood == (PossibleMoods)value).emoji;
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return MoodEmojis.FirstOrDefault(el => el.emoji == (string)value).mood;
        }
    }
}
