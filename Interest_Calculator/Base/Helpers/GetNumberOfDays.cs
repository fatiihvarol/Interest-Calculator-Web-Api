namespace Interest_Calculator.Base.Helpers
{
    // Faiz frekansına göre gün sayısını belirleyen yardımcı sınıf
    public class GetNumberOfDays
    {
        // İlgili faiz frekansına göre gün sayısını döndüren metot
        public static decimal GetDays(string InterestFrequency)
        {
            // İlgili faiz frekansına göre switch-case yapısı
            switch (InterestFrequency.ToLower())
            {
                case "gün":
                    return 1 / 365m; // Vade gün cinsinden
                case "ay":
                    return 1 / 12m; // Vade ay cinsinden
                case "yıl":
                    return 1; // Vade yıl cinsinden
                default:
                    return 1;
            }
        }
    }
}