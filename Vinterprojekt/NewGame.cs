//Borde egentligen ligga i gameengine men var så stor så den fick sin egna klass.
public class NewGame {
	public GameEngine gameEngine {get; set; }

	public NewGame(GameEngine gameEngine)
	{
		this.gameEngine = gameEngine;
	}

	//här skapas alla gameobjects för ett nytt spel.
	public void populate()
	{
		int id=1;

		//Sätt tickcount till 0.
		gameEngine.TickCount = 0;

		//Skapa spelaren.
		gameEngine.ThePlayer = new Player(id++,"Lucifer","A handsome detective",10,80,"outside",false);

		//Skapa npc:er.
		gameEngine.Npcs.Add(new NPC(id++, "Gregory","Owner of the house. Greg's uncle. Quite dead.",100,75,"library",false,new List<string>(){"I did it!", "I think Elizabeth is the guilty", "I am a vegan"},true));
		gameEngine.Npcs.Add(new NPC(id++, "Elizabeth", "Gregory's wife. In love with Greg",50,45,"livingroom",false,new List<string>(){"I did it!", "I think Jeeves is the guilty", "I am a penguin"},false)); 
		gameEngine.Npcs.Add(new NPC(id++, "Greg","Gregory’s nephew; in love with Winchester",120,80,"livingroom",false,new List<string>(){"I did it!", "I think Sarah is the guilty", "I am a russian attack helicopter"},false));
		gameEngine.Npcs.Add(new NPC(id++, "Sarah","Maid; having an affair with Gregory",90,55,"kitchen",false,new List<string>(){"I did it!", "I think Elizabeth is the guilty", "I am a android"},false));
		gameEngine.Npcs.Add(new NPC(id++, "Jeeves","The butler, definetly the killer",110,78,"hallway",false,new List<string>(){"I did it!", "I think I am the guilty", "I am a penguin too"},false));
		gameEngine.Npcs.Add(new NPC(id++, "Olivia", "Greg’s girlfriend",72,51,"livingroom",false,new List<string>(){"I did it!", "I think Winchester is the guilty", "I am a fruit"},false));
		gameEngine.Npcs.Add(new NPC(id++, "Winchester","Gardener; in love with Greg",130,92,"livingroom",false,new List<string>(){"I did it!", "I think Gregory commited suicide", "I am a fruity fruit"},false));

		//Skapa items.
		WaltherPKK walther = new WaltherPKK(id++,"WaltherPKK","A quite ordinary Walther PKK",1,"Examine text set by class");
		Item notebook = new Item(id++,"notebook","A well used notebook",1,"Examining the notebook carefully you realise that you are a bit dim witted");
		Item letter = new Item(id++, "letter", "An old letter with strange letter", 1, "You deciphered the letters and the word 'xyzzy' appears");

		//skapa furniture.
		Furniture mailbox = new Furniture(id++,"mailbox","A plain mailbox",false,20,"You look deep into the mailbox but you disscover nothing special about it");

		//Skapa alla rum med exits, furnitures och items.
		//First floor:
		Room outside = new Room(id++,"outside","You are just outside of the house where the murder has been commited. You are greeted by a beautiful view of the surrounding landscape. The house is situated on a large, well-manicured lawn that stretches out before you, with tall trees framing the edges of the property.\n\nTo your left, there's a small pond with a fountain in the center, the gentle sound of trickling water providing a soothing background noise. In the distance, you can see rolling hills and fields, with glimpses of farmhouses and barns dotting the landscape.\n\nTo your right, a winding driveway leads up to the house, lined with tall trees and shrubs that provide privacy and seclusion. As you look closer, you notice a small garden tucked away in a corner of the lawn, filled with vibrant flowers and fragrant herbs.\n\nOverall, the view outside of the house is peaceful and serene, with a sense of natural beauty that complements the elegance and charm of the home itself. Behind the open entrance door you see a hallway.");
		outside.Exits.Add("hallway");
		outside.Furnitures.Add(mailbox);
		outside.Items.Add(walther);
		gameEngine.Rooms.Add(outside);
		gameEngine.addRoomsIndex(outside.Name,gameEngine.Rooms.Count-1);

		Room hallway = new Room(id++,"hallway","As you step through the front door and into the house, you find yourself in a spacious and elegant hallway. The walls are painted a soft, neutral color, and the floors are made from polished hardwood that gleams in the light.\n\nThe hallway is well-lit, with several wall sconces casting a warm glow over the space. There's a large rug on the floor, made from plush wool, that adds a cozy feel to the area.\n\nTo your left, there's a coat closet with a mirrored door, perfect for hanging up your coat and checking your appearance before you enter the main part of the house. To your right, there's a small table with a vase of fresh flowers, providing a touch of natural beauty to the space.\n\nStraight ahead, a large archway leads into the main living area of the house, drawing your eye forward and inviting you to explore further. As you stand in the hallway, you can hear the sounds of laughter and conversation coming from beyond the archway, giving you a sense of the warmth and hospitality of the home.\n\nOverall, the hallway is a beautiful and welcoming introduction to the house, providing a glimpse of the elegance and charm that awaits you as you explore further.");
		hallway.Exits.Add("outside");
		hallway.Exits.Add("livingroom");
		hallway.Exits.Add("kitchen");
		hallway.Exits.Add("stairwell");
		hallway.Exits.Add("bathroom");
		hallway.Exits.Add("diningroom");
		gameEngine.Rooms.Add(hallway);
		gameEngine.addRoomsIndex(hallway.Name,gameEngine.Rooms.Count-1);

		Room kitchen = new Room(id++,"kitchen","The kitchen is a bustling, vibrant space, filled with the sounds and smells of cooking. The room is well-lit, with large windows that let in plenty of natural light, and there's a warmth and coziness to the space that makes you feel right at home.\n\nAt the center of the room is a large island, with a gleaming marble countertop and a built-in sink. The island is surrounded by high stools, making it the perfect place for casual meals or for guests to gather while you cook.\n\nThe walls of the kitchen are lined with a variety of cabinets and shelves, all filled with pots, pans, and cooking utensils. The cabinets are made from rich, dark wood, and the countertops are made from gleaming stainless steel.\n\nThere are several large appliances in the kitchen, including a commercial-grade oven and stove, a refrigerator, and a dishwasher. There's also a large walk-in pantry, which is stocked with a variety of dry goods and cooking staples.\n\nThe kitchen has a comfortable, lived-in feel, with personal touches like a chalkboard for writing shopping lists or leaving messages, and a collection of cookbooks arranged on a shelf.\n\nOverall, the kitchen is a place where meals are prepared with care and love. It's a space for creating and experimenting with new recipes, and for gathering with loved ones to share delicious food and good conversation.");
		kitchen.Exits.Add("hallway");
		kitchen.Exits.Add("diningroom");
		gameEngine.Rooms.Add(kitchen);
		gameEngine.addRoomsIndex(kitchen.Name,gameEngine.Rooms.Count-1);

		Room diningroom = new Room(id++,"diningroom","As you enter the dining room, you're immediately struck by the grandeur of the space. The room is large and airy, with high ceilings and elegant moldings that speak to its historical significance.\n\nAt the center of the room, a long wooden dining table dominates the space. The table is made from rich, dark wood, and is surrounded by high-backed chairs with plush cushions. The table is set with gleaming silver cutlery, delicate crystal glasses, and fine china plates, all arranged with impeccable precision.\n\nA large chandelier hangs from the ceiling, casting a warm glow over the room and illuminating the intricate patterns in the antique rug that covers the floor.\n\nAlong the walls of the room, there are several large cabinets and sideboards, which are filled with an impressive array of fine china, sparkling crystal, and silverware. These cabinets are illuminated from within, casting a soft glow over the ornate objects within.\n\nThe walls of the dining room are lined with paintings and other artworks, which range from classic still-life paintings to more modern abstract pieces. The room has a refined and cultured feel, designed for those who appreciate the finer things in life.\n\nOverall, the dining room is a space designed for lavish entertaining and grand occasions. It's a place to gather with friends and family, to indulge in delicious food and fine wine, and to savor the pleasures of life in grand style.");
		diningroom.Exits.Add("hallway");
		diningroom.Exits.Add("kitchen");
		gameEngine.Rooms.Add(diningroom);
		gameEngine.addRoomsIndex(diningroom.Name,gameEngine.Rooms.Count-1);

		Room livingroom = new Room(id++,"livingroom","The living room in the house is a grand space, designed for both comfort and elegance. As you enter, you are struck by the high ceilings, adorned with intricate molding and embellishments that speak to the craftsmanship of the era. The walls are painted in a soft, neutral hue that provides a perfect backdrop for the room's many pieces of furniture and decor.\n\nIn the center of the room, there is a plush sofa and several armchairs, arranged in a conversational grouping around a large coffee table. The sofa is upholstered in a luxurious velvet fabric that invites you to sink in and relax, while the armchairs are covered in a complementary pattern that adds interest to the space.\n\nAround the perimeter of the room, there are a number of interesting decorative elements, such as an antique grandfather clock that ticks quietly in one corner, and a grand piano that stands against one wall. Large windows with flowing drapes allow natural light to flood the room during the day, while elegant chandeliers provide a soft, warm glow in the evening.\n\nOverall, the living room in the house is a space that is both refined and comfortable, a perfect place to relax and enjoy the company of friends and family.");
		livingroom.Exits.Add("hallway");
		livingroom.Exits.Add("hidden:secretroom");
		gameEngine.Rooms.Add(livingroom);
		gameEngine.addRoomsIndex(livingroom.Name,gameEngine.Rooms.Count-1);

		Room secretroom = new Room(id++,"secretroom","The hidden door swings open soundlessly, revealing a small, hidden room nestled behind the paneling. The room is cozy and intimate, with soft lighting and plush furnishings.\n\nA low sofa occupies one corner of the room, covered in cushions and throws in rich, luxurious fabrics. Nearby, a small table is set with a tray of tea and delicate pastries, as though awaiting the arrival of a favored guest.\n\nThe walls of the room are lined with shelves, upon which a variety of objects are displayed. Antique books, exotic curios, and mysterious objects of indeterminate origin jostle for space on the crowded shelves.\n\nIn the center of the room, there is a large, ornate chest, which seems to be of great age and value. The chest is intricately carved, with filigreed patterns and symbols etched into its surface. You can't help but wonder what secrets it might contain.\n\nOverall, the small secret room hidden in the living room is a magical and mysterious space, designed for those who love to explore hidden corners and uncover hidden treasures. It's a place to escape from the bustle of the main living area, and to immerse oneself in a world of mystery and wonder.");
		secretroom.Exits.Add("livingroom");
		secretroom.Items.Add(letter);
		gameEngine.Rooms.Add(secretroom);
		gameEngine.addRoomsIndex(secretroom.Name,gameEngine.Rooms.Count-1);

		Room stairwell = new Room(id++,"stairwell","The stairwell in the house is a narrow passage that connects the main floor to the upper floors and the basement. The walls of the stairwell are painted in a rich, dark shade of mahogany, while the railing is crafted from wrought iron and features elegant scrolling patterns. The steps themselves are made of a polished wood that gleams in the light.\n\nWould you like to go up to the upper floors, where you can find the luxurious master suite and the elegant guest rooms, or would you like to descend to the basement, where you can explore the eerie storage room, the warm and inviting boiler room, or the laundry room with its piles of dirty clothes? As you make your choice, you can feel the weight of the house above you, and the creaking of the stairs underfoot only adds to the sense of age and mystery. The stairwell is illuminated by a series of elegant sconces that cast a warm, flickering light over the space, making the journey up or down that much more inviting..");
		stairwell.Exits.Add("hallway");  //Back to first floor
		stairwell.Exits.Add("mainarea"); //To Second floor
		stairwell.Exits.Add("basement"); //To the basement
		gameEngine.Rooms.Add(stairwell);
		gameEngine.addRoomsIndex(stairwell.Name,gameEngine.Rooms.Count-1);

		Room bathroom = new Room(id++,"bathroom","The smaller bathroom in the estate is a cozy and charming space, perfect for guests or for a quick wash up. The walls are painted in a soft shade of powder blue, giving the room a calming and peaceful ambiance. The floor is tiled in simple white ceramic tiles, and a small window lets natural light filter into the space.\n\nThe centerpiece of the bathroom is a simple pedestal sink, with a classic white porcelain basin and chrome fixtures. Above the sink, a small mirror with a silver frame hangs on the wall. The mirror reflects the light and adds a touch of elegance to the space.");
		bathroom.Exits.Add("hallway");
		gameEngine.Rooms.Add(bathroom);
		gameEngine.addRoomsIndex(bathroom.Name,gameEngine.Rooms.Count-1);

		//Second floor rooms:

		Room mainarea = new Room(id++,"mainarea","One of the highlights of the house is a spacious and inviting social area on the second floor, designed to accommodate gatherings and entertaining. The room is open and airy, with high ceilings and large windows that let in plenty of natural light.\n\nIn the center of the room, there is a large, comfortable sectional sofa that wraps around a low coffee table, creating a cozy conversation area. The sofa is upholstered in a soft, neutral fabric that complements the room's warm, inviting color scheme.\n\nOn one side of the room, there is a fully stocked bar, complete with a sink, refrigerator, and a variety of glassware. The bar is crafted from rich, dark wood that provides a sophisticated touch, and is topped with gleaming marble that adds a touch of elegance.\n\nAround the perimeter of the room, there are several smaller seating areas, each with a comfortable armchair or loveseat and a table. Large artworks adorn the walls, adding visual interest and texture to the space.\n\nOverall, the main area of the house is a place designed for relaxed and convivial gatherings, where guests can enjoy good company, delicious cocktails, and comfortable surroundings.");
		mainarea.Exits.Add("stairwell");
		mainarea.Exits.Add("library");
		mainarea.Exits.Add("office");
		mainarea.Exits.Add("masterbedroom");
		mainarea.Exits.Add("guestroom");
		mainarea.Exits.Add("bedroom");
		gameEngine.Rooms.Add(mainarea);
		gameEngine.addRoomsIndex(mainarea.Name,gameEngine.Rooms.Count-1);

		Room office = new Room(id++,"office","The owner of the grand estate has a magnificent office. As you step inside, you are struck by the sheer opulence of the room. The walls are paneled with dark, polished wood, and the bookshelves lining them are filled with leather-bound tomes and antique volumes. A large desk sits in the center of the room, surrounded by plush leather chairs and ornate lamps. The air is heavy with the scent of aged paper and rich mahogany.\n\nThe desk itself is a marvel, crafted from the finest materials and adorned with intricate carvings and brass fittings. The owner's chair is high-backed and cushioned, providing a regal seat for conducting business. The desk is cluttered with papers and inkwells, but everything is meticulously organized, reflecting the owner's attention to detail.\n\nIn one corner of the room, a large safe is concealed behind a painting of a landscape. The painting is so realistic that you almost miss it, but upon closer inspection, you see that it is a cleverly disguised facade for the safe. You can only imagine what treasures and secrets it might hold.\n\nDespite the grandeur of the room, there is a sense of seriousness and gravitas that permeates the air. This is a room where important decisions are made, where the fate of the estate and its inhabitants is determined. As you stand in the owner's office, you can't help but feel a sense of awe and respect for the person who commands this space.");
		office.Exits.Add("mainarea");
		gameEngine.Rooms.Add(office);
		gameEngine.addRoomsIndex(office.Name,gameEngine.Rooms.Count-1);

		Room library = new Room(id++, "library", "As you step into the library, you are immediately struck by the opulence and elegance of the space. The room is expansive, with high ceilings adorned with intricate moldings and ornate chandeliers hanging overhead. The walls are lined with towering bookshelves made of polished wood and accented with brass and gold hardware.\n\nThe shelves are meticulously arranged with books of all kinds, from literary classics to contemporary works. Each book is placed with care, aligned perfectly with the shelf and its neighbors. The titles are written in elegant serif fonts, and the spines are decorated with intricate patterns in bold, bright colors like deep blues, rich reds, and vibrant yellows.\n\nThe seating area is equally lavish, with plush armchairs and sofas arranged in small groupings around low tables. The furniture is upholstered in rich fabrics like velvet and silk, in colors that complement the books and the overall aesthetic of the space. The tables are adorned with vases of fresh flowers and decorative sculptures, adding to the overall sense of luxury.\n\nThe lighting in the space is soft and warm, with sconces and lamps casting a gentle glow on the books and the furnishings. The windows are large and arched, with heavy drapes in bold patterns and colors that provide both privacy and visual interest.");
		library.Exits.Add("librarybathroom");
		library.Exits.Add("mainarea");
		gameEngine.Rooms.Add(library);
		gameEngine.addRoomsIndex(library.Name,gameEngine.Rooms.Count-1);

		Room librarybathroom = new Room(id++, "librarybathroom", "As you step into the bathroom connected to the library, you are struck by the continuation of the style throughout the space. The bathroom is spacious and bright, with large windows that allow natural light to flood the room. The walls are tiled in a striking pattern of black and white, with accents of gold trim that echo the gold accents of the library.\n\nThe fixtures are made of gleaming chrome, with sleek lines and geometric shapes that are in keeping with the art deco aesthetic. The sink is set into a large vanity made of polished wood, with plenty of counter space for toiletries and personal items. The mirror above the sink is framed in gold, with intricate detailing that adds a touch of elegance to the space.\n\nThe toilet is situated in a separate water closet, providing privacy and adding to the functionality of the bathroom. The water closet is also tiled in black and white, with gold accents and a sleek, modern toilet.");
		librarybathroom.Exits.Add("library");
		gameEngine.Rooms.Add(librarybathroom);
		gameEngine.addRoomsIndex(librarybathroom.Name,gameEngine.Rooms.Count-1);

		Room masterbedroom = new Room(id++, "masterbedroom", "As you step into the room, you are struck by the size and grandeur of the space. The walls are painted in a soft, creamy white, with delicate moldings and ornate cornices that frame the high ceilings. The floors are made of polished wood, adding warmth and richness to the space.\n\nThe centerpiece of the room is the large four-poster bed, which is draped in luxurious silk sheets in a pale, subtle hue. The bed is set against an oversized headboard made of plush velvet, adding depth and texture to the space. The pillows are soft and plump, and the throw blanket at the foot of the bed is made of a soft, fluffy material.\n\nThe windows in the room are large and arched, with heavy drapes made of rich fabrics like silk and velvet. The drapes are adorned with intricate patterns and bold colors, adding visual interest and depth to the space. The windows offer a view of the lush gardens and rolling hills surrounding the estate, adding to the sense of tranquility and peace in the room.\n\nThe seating area in the room is equally opulent, with plush armchairs and a sofa arranged around a low table. The furniture is upholstered in soft, rich fabrics in hues that complement the overall color scheme of the room. The tables are adorned with decorative sculptures, vases of fresh flowers, and other elegant touches that add to the overall sense of luxury.\n\nThe lighting in the room is soft and warm, with chandeliers and sconces casting a gentle glow on the furnishings and decor. The walls are adorned with art and mirrors, adding depth and interest to the space.");
		masterbedroom.Exits.Add("mainarea");
		masterbedroom.Exits.Add("masterbathroom");
		gameEngine.Rooms.Add(masterbedroom);
		gameEngine.addRoomsIndex(masterbedroom.Name,gameEngine.Rooms.Count-1);

		Room masterbathroom = new Room(id++, "masterbathroom", "The master bathroom is a stunning example of opulence and indulgence. As you step inside, you're immediately struck by the sheer size of the space. The walls are lined with marble, and the floors are made of gleaming polished stone. A large window overlooking the gardens lets natural light filter into the room, and a crystal chandelier hangs from the ceiling, casting a soft glow over everything.\n\nThe centerpiece of the bathroom is a massive soaking tub, big enough for two people to lounge in comfortably. The tub is surrounded by intricately carved marble columns, giving it the appearance of a royal bath. Nearby is a spacious shower with multiple heads, perfect for a luxurious spa-like experience.\n\nIn the center of the room is a long double vanity, crafted from rich mahogany and topped with gleaming marble. The vanity is stocked with luxurious bath products and plush towels, inviting you to indulge in a relaxing spa experience. A large mirror framed in gold hangs above the vanity, reflecting the beauty of the space and adding to its opulence.\n\nThe master bathroom is a true sanctuary of relaxation and indulgence. The luxurious materials, spacious layout, and attention to detail make it a true oasis within the already luxurious home.");
		masterbathroom.Exits.Add("masterbedroom");
		gameEngine.Rooms.Add(masterbathroom);
		gameEngine.addRoomsIndex(masterbathroom.Name,gameEngine.Rooms.Count-1);

		Room bedroom = new Room(id++, "bedroom", "As you step into the bedroom that once belonged to the Greg, you are struck by the continuation of the style throughout the space. The room is spacious and bright, with large windows that allow natural light to flood the room. The walls are painted in a soft, pale shade of blue, with accents of black and gold trim that echo the art deco style of the mansion.\n\nThe centerpiece of the room is a large, ornate bed that is situated against one wall. The bed is made of polished wood, with a curved headboard and footboard that are adorned with intricate patterns and carvings. The bed is covered in luxurious silk sheets in a pale shade of blue, with plush pillows and a cozy throw blanket.\n\nIn one corner of the bedroom there is a dresser that adds both style and functionality to the space. The dresser is made of polished wood, with clean lines and geometric shapes. The dresser is adorned with decorative accents in gold and a table top made of marbe, adding a touch of luxury to the space.\n\nThe top of the dresser is adorned with a few personal items, including a small vase of dead flowers and a few framed photographs. The drawers of the dresser are spacious and offer plenty of storage for clothing and other personal items. The handles of the drawers are made of sleek, black metal, adding a modern touch to the piece.The windows in the room are adorned with heavy drapes made of rich, black velvet. The drapes are adorned with intricate patterns in gold, adding visual interest and depth to the space. The windows offer a view of the surrounding gardens and estate, creating a sense of peace and tranquility.\n\nThe seating area in the room is elegant and sophisticated, with a plush armchair and a small table arranged in one corner. The table is adorned with a decorative sculpture, adding a touch of natural beauty to the space.\n\nThe lighting in the room is soft and warm, with a large chandelier casting a gentle glow on the furnishings and decor. The walls are adorned with art and photographs, adding a personal touch to the space.");
		bedroom.Exits.Add("mainarea");
		gameEngine.Rooms.Add(bedroom);
		gameEngine.addRoomsIndex(bedroom.Name,gameEngine.Rooms.Count-1);

		Room guestroom = new Room(id++, "guestroom", "As you step into the guestroom in the grand estate, you are struck by the cozy and welcoming atmosphere of the space. The room is smaller than the other bedrooms in the house, but it is no less luxurious. The walls are painted in a soft, neutral shade, with delicate moldings and ornate cornices that add elegance and sophistication to the space. The floors are covered in plush carpeting that adds warmth and comfort.\n\nThe centerpiece of the room is a comfortable bed that is covered in soft, high-quality linens. The bed is situated against one wall and is adorned with plush pillows and a cozy throw blanket. The headboard of the bed is upholstered in a soft, neutral fabric that complements the overall color scheme of the room.\n\nThe windows in the room are smaller than those in the other bedrooms, but they still allow plenty of natural light to enter the space. The windows are adorned with delicate drapes made of sheer fabric, which adds to the cozy and welcoming atmosphere of the room.\n\nThere is a small seating area in one corner of the room, with a comfortable armchair and a side table. The side table is adorned with a decorative lamp and a vase with fresh flowers.\n\nThe lighting in the room is soft and warm, with a table lamp casting a gentle glow on the furnishings and decor. The walls are adorned with a few pieces of art and a decorative mirror, adding depth and interest to the space.");
		guestroom.Exits.Add("mainarea");
		gameEngine.Rooms.Add(guestroom);
		gameEngine.addRoomsIndex(guestroom.Name,gameEngine.Rooms.Count-1);

		//Basement rooms:

		Room basement = new Room(id++, "basement", "As you descend the creaky stairs to the basement of the grand estate, the air grows colder and the light becomes more scarce. The only source of illumination is a flickering bulb that casts eerie shadows on the rough concrete walls. The dampness of the air hangs heavily, and a musty odor pervades the space. The basement feels like a different world entirely, a place where time has stopped and forgotten objects have been left to rot.\n\nThe space is divided into several rooms, each more foreboding than the last. Cobwebs stretch from wall to wall, and the musty smell is overpowering. You can hear the faint sounds of dripping water somewhere in the distance, a steady and eerie reminder that you are deep below the earth's surface.\n\nAs you move through the basement, you begin to feel more and more uneasy. From the shadowy corners you can't quite see what lies ahead, and a strange noises seem to come from nowhere. The space feels like a place where the ghosts of past owners still linger, and the wine storage by the left wall seems to hold something more sinister than just rows of bottles.");
		basement.Exits.Add("stairwell");
		basement.Exits.Add("boilerroom");
		basement.Exits.Add("storage");
		basement.Exits.Add("laundry");
		gameEngine.Rooms.Add(basement);
		gameEngine.addRoomsIndex(basement.Name,gameEngine.Rooms.Count-1);

		Room laundry = new Room(id++, "laundry", "The laundry room in the basement of the grand estate is a cramped and musty space that seems frozen in time. The room is dimly lit, with a single bare light bulb casting a yellowish glow over everything. The walls are made of rough concrete, and the floors are covered in old linoleum that has peeled up at the corners.\n\nThe centerpiece of the room is a set of ancient industrial washing machines and dryers, their surfaces coated in grime and. The machines creak and groan as they slowly turn, emitting a rhythmic banging sound that echoes off the concrete walls. The laundry baskets are piled high with foul-smelling and wrinkled garments, as if they have been forgotten there for years. There is so much laundry that it seems to have spilled over onto the floor, forming a mound of dirty clothes that takes up a significant portion of the room.\n\nAs you move further into the room, you notice the strange items scattered around the space. On a shelf above the washers, you see a row of old detergent boxes, their faded labels barely legible. In the corner, a basket of mismatched socks sits, as if waiting for their owners to return and claim them. In another corner, you see a row of old ironing boards, covered in cobwebs and rust.\n\nDespite its rundown appearance, the laundry room feels like a place where the ghosts of past owners still linger. You can almost hear the distant sounds of laundry being washed and hung to dry, as if the room is a portal to a bygone era. The musty smell is overpowering, and the sight of the mound of laundry is almost suffocating. But there is something oddly comforting about the familiarity of the space.\n\nThe abundance of dirty laundry adds to the eerie atmosphere of the room, making it feel as if the ghosts of past owners are still present, waiting for their laundry to be done.");
		laundry.Exits.Add("basement");
		gameEngine.Rooms.Add(laundry);
		gameEngine.addRoomsIndex(laundry.Name,gameEngine.Rooms.Count-1);

		Room storage = new Room(id++, "storage", "The storage room is a vast and labyrinthine space, filled with rows of dusty shelves and old trunks. The room is dimly lit, with only a few weak bulbs hanging from the ceiling, casting flickering shadows across the walls. The air is thick with the smell of dust and mildew, and every step echoes loudly against the concrete floor.\n\nThe shelves are crammed with an assortment of boxes, each one filled with forgotten items from a different era. Some boxes are adorned with fading labels, while others are unmarked, their contents a mystery. Here and there, a cobweb-covered chandelier or a broken chair sits abandoned, waiting for someone to give them new life.\n\nAs you make your way through the maze of shelves, you notice a covered painting peeking out from behind a stack of boxes in the far corner of the room. It is only barely visible, but you can just make out the edge of a frame. It seems as if the painting has been left rather recently as it opposed to everything else in the room has neglected to gather dust and cobwebs.\n\nDespite the musty smell and the eerie atmosphere of the storage room, you feel drawn to the painting. You carefully make your way through the maze of boxes, stepping over piles of forgotten items and dodging spider webs, until you finally reach the corner where the painting is hidden. With trembling fingers, you slowly peel away the soft linen sheets and reveal the painting in all its glory.\n\nThe painting is a stunning masterpiece, with vibrant colors and intricate details that have been preserved despite years of neglect. As you gaze at it, you feel a sense of awe and wonder, and you wonder how such a magnificent work of art could have been left to gather dust in the forgotten corners of the estate's basement storage room.");
		storage.Exits.Add("basement");
		gameEngine.Rooms.Add(storage);
		gameEngine.addRoomsIndex(storage.Name,gameEngine.Rooms.Count-1);

		Room boilerroom = new Room(id++, "boilerroom", "As you descend the hallway of the basement, the air grows warmer and thicker, and a low hum fills your ears. The sound grows louder as you approach a heavy door at the end of a dimly-lit corridor. You push the door open, and you are hit by a wave of heat and the deafening roar of the boiler.\n\nThe boiler room is a cramped space, filled with pipes and valves that hiss and clank with the rhythm of the machine. The air is thick with the smell of burning coal and oil, and sweat beads on your forehead as you take in the scene. You can feel the warmth radiating from the boiler, suffusing the entire room with a red glow.\n\nDespite the warmth, you feel a shiver run down your spine. There is something eerie about this room, something that makes you feel as if you are not alone. The shadows dance across the walls, and you can hear strange whispers echoing in the hiss of the steam.\n\nThe boiler room is not a place for the faint of heart. It is a place of heat and noise, of danger and intrigue. And as you stand there, staring into the red glow of the boiler, you realize that there is more to this room than meets the eye.");
		boilerroom.Exits.Add("basement");
		gameEngine.Rooms.Add(boilerroom);
		gameEngine.addRoomsIndex(boilerroom.Name,gameEngine.Rooms.Count-1);

		//Ge spelaren en notebook.
		gameEngine.ThePlayer.addToInventory(notebook);

		//Placerar ut alla npc:er slumpmässigt.
		Random rand = new Random();
		int roomNumber;
		foreach(NPC curNPC in gameEngine.Npcs)
		{
			roomNumber =  rand.Next(1,gameEngine.Rooms.Count);  //0 är outside där npc inte kan gå.
			curNPC.CurrentRoom = gameEngine.Rooms.ElementAt(roomNumber).Name;
		}

		//Slumpa mördaren.
		int randomKiller = rand.Next(0,gameEngine.Npcs.Count);

		NPC theKiller = gameEngine.Npcs.ElementAt(randomKiller);
		theKiller.IsTheKiller = true;
	}
}
