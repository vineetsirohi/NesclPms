namespace NesclPms.Domain.Entities
{
    class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string Pin { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}