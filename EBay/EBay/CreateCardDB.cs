using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EBay {
	public class CreateCardDB {
		public Set[] sets;
		public Card[] all_cards;

		public CreateCardDB(string[] files, string all_cards_file) {
			sets = new Set[files.Length];
			int i;
			StreamReader r;
			string json;

			for(i = 0; i < files.Length; i++) {
				r = new StreamReader(files[i]);
				json = r.ReadToEnd();
				sets[i] = new Set(JsonConvert.DeserializeObject<dynamic>(json));
			}

			r = new StreamReader(all_cards_file);
			json = r.ReadToEnd();
			JObject all_cards_json = JsonConvert.DeserializeObject<dynamic>(json);
			all_cards = new Card[all_cards_json.Count];
			i = 0;
			foreach(KeyValuePair<string, JToken> t in all_cards_json) {
				all_cards[i] = new Card(t.Value);
				i++;
			}

			int cards = 0;
			foreach(Set s in sets) {
				if(s.cards != null)
					cards += s.cards.Length;
			}
			Console.WriteLine("Read all files!\n{0} sets were saved\n{1} cards were saved\n{2} unique cards were saved", sets.Length, cards, all_cards.Length);
		}
	}

	public class Set {
		// Standard set fields.
		public string name;
		public string code;
		public string gathererCode;
		public string oldCode;
		public string magicCardsInfoCode;
		public string releaseDate;
		public string border;
		public string type;
		public string block;
		public string onlineOnly;
		public JArray booster;
		public Card[] cards;

		public Set(dynamic set_json) {
			name = set_json.name;
			code = set_json.code;
			gathererCode = set_json.gathererCode;
			oldCode = set_json.oldCode;
			magicCardsInfoCode = set_json.magicCardsInfoCode;
			releaseDate = set_json.releaseDate;
			border = set_json.border;
			type = set_json.type;
			block = set_json.block;
			onlineOnly = set_json.onlineOnly;
			booster = set_json.booster;
			JArray cards_jarray = set_json.cards;
			cards = new Card[cards_jarray.Count];
			for(int i = 0; i < cards_jarray.Count; i++) {
				cards[i] = new Card(cards_jarray[i]);
			}
		}
	}

	public class Card {
		// Standard card fields
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
		// Extra fields
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