namespace WebApplication.Domain
{
    public class Fahrenheit 
    {
        protected bool Equals(Fahrenheit other)
        {
            return Temperature.Equals(other.Temperature);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Fahrenheit) obj);
        }

        public override int GetHashCode()
        {
            return Temperature.GetHashCode();
        }

        public Fahrenheit(Celsius celsius) : this(celsius.Temperature * 1.8D + 32){ }

        public Fahrenheit(double temperature)
        {
            Temperature = temperature;
        }
        
        public double Temperature { get; }
    }
}