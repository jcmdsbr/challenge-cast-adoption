namespace SGA.Infra.CrossCutting.Extensions
{
    public static class StringExtensions
    {
        public static string UnMaskCpf(this string value)
        {
            return value.Replace(".", string.Empty).Replace("-", string.Empty);
        }
    }
}