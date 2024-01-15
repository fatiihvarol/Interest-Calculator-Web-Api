namespace Interest_Calculator.Base.Helpers
{
    // Interest frekansına göre bileşikleme periyodunu belirleyen yardımcı sınıf
    public class GetNumberOfCompoundingPeriods
    {
        // İlgili frekans için bileşikleme periyodunu döndüren metot
        public static decimal Get(string interestFrequency)
        {
            // İlgili frekansa göre switch-case yapısı
            switch (interestFrequency.ToLower())
            {
                case "gün":
                    return 365m;
                case "ay":
                    return 12m;
                case "yıl":
                    return 1m;
                default:
                    return 1m;
            }
        }
    }
}