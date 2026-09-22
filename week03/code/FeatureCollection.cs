public class FeatureCollection
{
    // TODO Problem 5 - ADD YOUR CODE HERE
    // Create additional classes as necessar

    public string Type { get; set; }
    public Feature[] Features { get; set; }
}

public class Feature
{
    public string Type { get; set; }
    public Geometry Geometry { get; set; }
    public Properties Properties { get; set; }
}

public class Geometry
{
    public string Type { get; set; }
    public double[] Coordinates { get; set; }
}

public class Properties
{
    public string Place { get; set; }
    public double Mag { get; set; }
}
