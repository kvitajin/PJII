using System.Collections.Generic;

namespace test2 {
    public interface IConsumer {
        double Balance { get; set; }
        List<uint> History { get; set; }
        string Name { get; set; }
        PowerPlant PowerPlant { get; set; }
    }
}