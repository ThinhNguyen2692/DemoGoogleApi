using System.Collections.Generic;
using Newtonsoft.Json;

public class CardMessage
{
    [JsonProperty("cards")]
    public List<Card> Cards { get; set; }
}

public class Card
{
    [JsonProperty("header")]
    public Header Header { get; set; }

    [JsonProperty("sections")]
    public List<Section> Sections { get; set; }
}

public class Header
{
    [JsonProperty("title")]
    public string Title { get; set; }
}

public class Section
{
    [JsonProperty("header")]
    public string SectionHeader { get; set; }

    [JsonProperty("widgets")]
    public List<Widget> Widgets { get; set; }
}

public class Widget
{
    [JsonProperty("textParagraph")]
    public TextParagraph TextParagraph { get; set; }

    [JsonProperty("keyValue")]
    public KeyValue KeyValue { get; set; }

    [JsonProperty("buttons")]
    public List<Button> Buttons { get; set; }
}

public class TextParagraph
{
    [JsonProperty("text")]
    public string Text { get; set; }
}

public class KeyValue
{
    [JsonProperty("topLabel")]
    public string TopLabel { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }
}

public class Button
{
    [JsonProperty("textButton")]
    public TextButton TextButton { get; set; }
}

public class TextButton
{
    [JsonProperty("text")]
    public string Text { get; set; }

    [JsonProperty("onClick")]
    public OnClick OnClick { get; set; }
}

public class OnClick
{
    [JsonProperty("openLink")]
    public OpenLink OpenLink { get; set; }
}

public class OpenLink
{
    [JsonProperty("url")]
    public string Url { get; set; }
}
