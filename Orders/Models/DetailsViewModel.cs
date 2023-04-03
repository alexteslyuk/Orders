using Orders.Logic.DTOs;

namespace Orders.Models
{
    public class DetailsViewModel
    {
        public OrderDTO Order { get; set; }
        public IEnumerable<string> Names { get; set; }
        public IEnumerable<string> SelectedNames { get; set; }
        public IEnumerable<string> Units { get; set; }
        public IEnumerable<string> SelectedUnits { get; set; }
    }
}
