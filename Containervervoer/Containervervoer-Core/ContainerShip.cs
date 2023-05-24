using System.Globalization;

namespace Containervervoer_Core;

public class ContainerShip
{
	private int length { get; set; }
	private int width { get; set; }
	private int height { get; set; }
    public Container[,,] containers { get; set; }
	private int maxWeight { get; set; }
	private int[,] weightDistibution { get; set; }

	public ContainerShip(int length, int width, int height, int maxWeight)
	{
		this.length = length;
		this.width = width;
		this.height = height;
		containers = new Container[length, width, height];
		weightDistibution = new int[length, width];

		for (int i = 0; i < length; i++)
			for (int j = 0; j < width; j++)
				weightDistibution[i, j] = 0;

		this.maxWeight = maxWeight;
	}

	public void AddContainer(Container container, int placeLength, int placeWidth)
	{
		bool succes = false;
		for (int i = 0; i < height; i++)
		{
			if (containers[placeLength, placeWidth, i] == null)
			{
				containers[placeLength, placeWidth, i] = container;
				succes = true;
				break;
			}
		}

		if (!succes)
			throw new Exception("This place on the ship is allready full");

		weightDistibution[placeLength, placeWidth] += container.weight;
    }

	public int CalculateTotalWeight()
	{
		int result = 0;
		foreach (int weight in weightDistibution)
			result += weight;
		return result;
	}

	public int CalculateBalance()
	{
        int leftWeight = 0;
        int rightWeight = 0;

        for (int i = 0; i < length; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (j < width / 2)
                    leftWeight += weightDistibution[i, j];
                else
                    rightWeight += weightDistibution[i, j];
            }
        }

		int result = rightWeight - leftWeight;

		return result;
    }
}