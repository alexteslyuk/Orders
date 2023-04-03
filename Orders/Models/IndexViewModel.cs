using Orders.Logic.DTOs;

namespace Orders.Models
{
    public class IndexViewModel
    {
        public IEnumerable<string> Numbers { get; set; }
        public IEnumerable<string> SelectedNumbers { get; set; } = new List<string>();
        public IEnumerable<ProviderDTO> Providers { get; set; }
        public IEnumerable<int> SelectedProviders { get; set; } = new List<int>();
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<OrderDTO> Orders { get; set; }
    }
}
