using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EBay {
	public class CreateCardDB {
		public CreateCardDB(string[] files) {
			StreamReader r;
			foreach(string file in files) {
				r = new StreamReader(file);
				string json = r.ReadToEnd();
				Set s = new Set(JsonConvert.DeserializeObject<dynamic>(json));
			}
		}
	}

	public class Set {
		public Set(dynamic set_json) {
			string name = set_json.name;
			string code = set_json.code;
			string gathererCode = set_json.gathererCode;
			string magicCardsInfoCode = set_json.magicCardsInfoCode;
			string releaseDate = set_json.releaseDate;
			string border = set_json.border;
			string type = set_json.type;
			JArray booster = set_json.booster;
			string mkm_name = set_json.mkm_name;
			string mkm_id = set_json.mkm_id;
			JArray cards_jarray = set_json.cards;
			Card[] cards = new Card[cards_jarray.Count];
			for(int i = 0; i < cards_jarray.Count; i++) {
				cards[i] = new Card(cards_jarray[i]);
			}
		}
	}

	public class Card {
		public string id;
		public string layout;
		public string name;
		public JArray names;
		public string manaCost;
		public string cmc;
		public JArray colors;
		public JArray colorIdentity;
		public string type;
		public JArray supertypes;
		public JArray types;
		public JArray subtypes;
		public string rarity;
		public string text;
		public string flavor;
		public string artist;
		public string number;
		public string power;
		public string toughness;
		public string loyalty;
		public string multiverseid;
		public JArray variations;
		public string imageName;
		public string watermark;
		public string border;
		public string timeshifted;
		public string hand;
		public string life;
		public string reserved;
		public string releaseDate;
		public string starter;
		public string mciNumber;

		public JArray rulings;
		public JArray foreignNames;
		public JArray printings;
		public string originalText;
		public string originalType;
		public JArray legalities;
		public string source;

		public Card(dynamic card_json) {
			id = card_json.id;
			layout = card_json.layout;
			name = card_json.name;
			names = card_json.names;
			manaCost = card_json.manaCost;
			cmc = card_json.cmc;
			colors = card_json.colors;
			colorIdentity = card_json.colorIdentity;
			type = card_json.type;
			supertypes = card_json.supertypes;
			types = card_json.types;
			subtypes = card_json.subtypes;
			rarity = card_json.rarity;
			text = card_json.text;
			flavor = card_json.flavor;
			artist = card_json.artist;
			number = card_json.number;
			power = card_json.power;
			toughness = card_json.toughness;
			loyalty = card_json.loyalty;
			multiverseid = card_json.multiverseid;
			variations = card_json.variations;
			imageName = card_json.imageName;
			watermark = card_json.watermark;
			border = card_json.border;
			timeshifted = card_json.timeshifted;
			hand = card_json.hand;
			life = card_json.life;
			reserved = card_json.reserved;
			releaseDate = card_json.releaseDate;
			starter = card_json.starter;
			mciNumber = card_json.mciNumber;

			rulings = card_json.rulings;
			foreignNames = card_json.foreignNames;
			printings = card_json.printings;
			originalText = card_json.originalText;
			originalType = card_json.originalType;
			legalities = card_json.legalities;
			source = card_json.source;
		}
	}
}