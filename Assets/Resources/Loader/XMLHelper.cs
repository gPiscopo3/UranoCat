using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

public static class XMLHelper
{
    public static Cat LoadCatFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Cat));

        using (StreamReader reader = new StreamReader(filePath))
        {
            return (Cat)serializer.Deserialize(reader);
        }
    }

    public static void SaveCatToXml(Cat cat, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Cat));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, cat);
        }
    }

    public static Player LoadPlayerFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Player));

        using (StreamReader reader = new StreamReader(filePath))
        {
            return (Player)serializer.Deserialize(reader);
        }
    }

    public static void SavePlayerToXml(Player player, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Player));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, player);
        }
    }

    public static void SaveMissionsToXml(List<Mission> missions, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, missions);
        }
    }

    public static List<Mission> LoadMissionsFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<Mission>));

        using (StreamReader reader = new StreamReader(filePath))
        {
            return (List<Mission>)serializer.Deserialize(reader);
        }
    }

    public static void SaveShopItemsToXml(List<ShopItem> shopItems, string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<ShopItem>));

        using (StreamWriter writer = new StreamWriter(filePath))
        {
            serializer.Serialize(writer, shopItems);
        }
    }

    public static List<ShopItem> LoadShopItemsFromXml(string filePath)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(List<ShopItem>));

        using (StreamReader reader = new StreamReader(filePath))
        {
            return (List<ShopItem>)serializer.Deserialize(reader);
        }
    }

}