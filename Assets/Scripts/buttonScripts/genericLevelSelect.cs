using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class genericLevelSelect : MonoBehaviour {
    public string song_name;
    public int levelNum;
    int price;
    string message;

    //The scene that the player will be at
    string scene;

    bool validSong;
    string currentSong;

    Text songName;
    Text background;

    Text buttonText;

    Button thisButton;

    void Awake()
    {
        //Back alley
        if (song_name == "Mary Had a Little Lamb" && GlobalVariables.storyMode)
        {
            message = "You are Forté Pianissimo, a poor and hapless bum who has a dream of one day becoming a great composer.  Throughout the years of living on the streets, generous donors have given you in total $5000, enough to start a small orchestra.  You have decided to put on a street performance in the alley where you frequent.  Perhaps this is the start of something new?";
            currentSong = "MaryHadALittleLamb";
            scene = "backAlley";
            validSong = true;
        }
        //Back alley
        else if (song_name == "Fur Elise" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[1])
        {
            song_name = "Fur Elise by Beethoven";
            message = "Now you have got the attention of your audience.  Wow them once more with a song by Beethoven to show them that you deserve a second look.";
            currentSong = "FurElise";
            scene = "backAlley";
            validSong = true;
        }
        //Halloween
        else if (song_name == "In the Hall of the Mountain King" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[2])
        {
            song_name = "In the Hall of the Mountain King by Edvard Grieg";
            message = "You have achieved just a little bit more fame and now have decided to play at the local Halloween ball.  Spooky.";
            currentSong = "InTheHallOfTheMountainKing";
            scene = "halloween";
            validSong = true;
        }
        //Generic
        else if (song_name == "Eine Kleine Nachtmusik" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[3])
        {
            song_name = "Eine Kleine Nachtmusik by Mozart";
            message = "Another local gig.  You have decided to take it easy with a pleasant song by Mozart.";
            currentSong = "EineKleineNachtmusik";
            scene = "generic";
            validSong = true;
        }
        //Singapore
        else if (song_name == "Canon in D" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[4])
        {
            song_name = "Canon in D by Pachelbel";
            message = "You have decided to play for a local concert at the Botanical Gardens in Singapore while you are on a vacation of sorts.";
            currentSong = "CanonInD";
            scene = "singapore";
            validSong = true;
        }
        //Barbershop
        else if (song_name == "Sabre Dance" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[5])
        {
            song_name = "Sabre Dance";
            message = "You have decided to get a haircut and your orchestra has decided to tag along with you in your shenanigans.";
            currentSong = "SabreDance";
            scene = "barbershop";
            validSong = true;
        }
        //Berlin
        else if (song_name == "5th Symphony First Movement" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[6])
        {
            song_name = "5th Symphony First Movement by Beethoven";
            message = "This is the very first time that your orchestra plays at an actual concert hall.  You are nervous and don't know what you are doing.  Yet... you are filled with DETERMINATION.";
            currentSong = "5thSymphony";
            scene = "berlin";
            validSong = true;
        }
        //Bar
        else if (song_name == "Moonlight Sonata" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[7])
        {
            song_name = "Moonlight Sonata by Beethoven";
            message = "Your gig didn't go as well it ought have.  The audience booed you off the stage because your performance wasn't \"perfect\" enough.  You are now drinking at the bar while the piano player is jamming.";
            currentSong = "MoonlightSonata1";
            scene = "bar";
            validSong = true;
        }
        //Bar
        else if (song_name == "Ave Maria" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[8])
        {
            song_name = "Ave Maria by Schubert";
            message = "Your performance at the bar astounded all that attended.  You are now relaxed and feel in charge.  You are now praising your lord and savior for helping you attain this newfound position.";
            currentSong = "AveMaria";
            scene = "bar";
            validSong = true;
        }
        //Halloween
        else if (song_name == "Toccata in Fugue" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[9])
        {
            song_name = "Toccata in Fugue by Bach";
            message = "Halloween has just come around the corner once again.  You are now scheduled to play at the Halloween Festival. There will be a larger audience this time.  Are you ready?";
            currentSong = "ToccataInFugue";
            scene = "halloween";
            validSong = true;
        }
        //Harvard
        else if (song_name == "Pomp and Circumstance" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[10])
        {
            song_name = "Pomp and Circumstance by Sir Edgar Elgar";
            message = "Your fame has now made Harvard University consider your orchestra to play the graduation music.  You better not mess this one up.";
            currentSong = "PompAndCircumstance";
            scene = "harvard";
            validSong = true;
        }
        //Berlin
        else if (song_name == "Bolero" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[11])
        {
            song_name = "Bolero by Ravel";
            message = "You have now returned to the concert hall that you were originally booed from.  You are going to return with a vengeance.  You WILL wow the audience this time.";
            currentSong = "Bolero";
            scene = "berlin";
            validSong = true;
        }
        //Graveyard
        else if (song_name == "Erlkonig" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[12])
        {
            song_name = "Erlkonig by Schubert";
            message = "After drinking heavy amounts of vodka, you are now having a haunting hallucination in a graveyard of your mind.  Can your band save you from this horror?";
            currentSong = "Erlkonig";
            scene = "graveyard";
            validSong = true;
        }
        //Spooks
        else if (song_name == "O Fortuna" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[13])
        {
            song_name = "O Fortuna by Carl Orff";
            message = "Your nightmare is now climaxing and somehow you are now playing on stage and the audience consists of demons.  Will you ever wake up? Or is this nightmare real life?";
            currentSong = "OFortuna";
            scene = "spooks";
            validSong = true;
        }
        //Paris
        else if (song_name == "Carmen" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[14])
        {
            song_name = "Carmen: Habanera and Les Toreadors by Georges Bizet";
            message = "You are now touring with a well-known theatre group in Paris playing the background music to Carmen.  Perhaps this will convince the common people operas can be awesome.";
            currentSong = "CarmenHabanera";
            scene = "paris";
            validSong = true;
        }
        //Spacecenter
        else if (song_name == "Mars" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[15])
        {
            song_name = "Mars (from the Planets) by Gustav Holst";
            message = "The Kennedy Space Center is now launching its first crew to Mars.  They have decided to book you to commemorate this momentous occasion. Do not crash and burn.";
            currentSong = "Mars";
            scene = "spaceCenter";
            validSong = true;
        }
        //Russianforest
        else if (song_name == "Peter and the Wolf" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[16])
        {
            song_name = "Peter and the Wolf by Prokofiev";
            message = "You are taking much needed vacation time in the woodlands of Russia.  There, you will be hunting and your band will be playing along while you are on the hunt.  Will you catch a wolf or will a wolf catch you?";
            currentSong = "PeterAndTheWolf";
            scene = "russianWoods";
            validSong = true;
        }
        //Berlin
        else if (song_name == "Ride of the Valkyries" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[17])
        {
            song_name = "Ride of the Valkyries by Wagner";
            message = "Germany, a country known for having one of the biggest egoes ever, has funded you quite heftily; but you must play a special song for them in order to get your reward.";
            currentSong = "RideOfTheValkyries";
            scene = "berlin";
            validSong = true;
        }
        //Danube
        else if (song_name == "Blue Danube Waltz" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[18])
        {
            song_name = "Blue Danube Waltz by Strauss";
            message = "The wealthy citizens of Vienna are having a cruise and they have invited you to play while they are on the Danube river.  It should be a relaxing time.";
            currentSong = "BlueDanubeWaltz";
            scene = "danube";
            validSong = true;
        }
        //Magiccastle
        else if (song_name == "Sorcerer's Apprentice" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[19])
        {
            song_name = "Sorcerer's Apprentice by Paul Dukas";
            message = "You're a wizard, Forte.  After doing heavy drugs, you are now touring a special magic school, and your instruments are now floating and ALIVE! Imagine that!";
            currentSong = "SorcerersApprentice";
            scene = "magicalCastle";
            validSong = true;
        }
        //Berlin
        else if (song_name == "Ode to Joy" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[20])
        {
            song_name = "Ode to Joy by Beethoven";
            message = "The Germans couldn't get enough of you and they have asked (demanded) you to return.  They are giving you an offer you simply cannot refuse (considering you have wasted everything you had on drugs).";
            currentSong = "OdeToJoy";
            scene = "berlin";
            validSong = true;
        }
        //Horserace
        else if (song_name == "William Tell Overture" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[21])
        {
            song_name = "William Tell Overture by Giachano";
            message = "A day at the races!  You have placed a bet on one horse, Sir Henry Jr., because you believe he is the horse for the job.  Will you actually win the bet or will you simply get outpaced?";
            currentSong = "WilliamTellOverture";
            scene = "horseRace";
            validSong = true;
        }
        //Horserace
        else if (song_name == "Infernal Galop" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[22])
        {
            song_name = "Infernal Galop (Can Can) by Offenbach";
            message = "Sir Henry Jr. won the first race! Will he win the second one?! WILL HE WIN THE TRIPLE HORSESHOE?!";
            currentSong = "CanCan";
            scene = "horseRace";
            validSong = true;
        }
        //Horsefuneral
        else if (song_name == "Funeral March" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[23])
        {
            song_name = "Funeral March by Chopin";
            message = "Sir Henry Jr. crashed into a wall and died at the third race.  You are now forced to play music for the horse's funeral in order to pay back your gambling debts.  Poor you... Poor horse...";
            currentSong = "FuneralMarch";
            scene = "horseFuneral";
            validSong = true;
        }
        //Vienna
        else if (song_name == "Turkish March" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[24])
        {
            song_name = "Rondo Alla Turca (Turkish March) by Mozart";
            message = "Your reputation as someone who engages in copious amounts of substances and gambles has given the public a bad image of you.  Wow Vienna's socks off in order to show them once more you deserve respect and credibility.";
            currentSong = "TurkishMarch";
            scene = "vienna";
            validSong = true;
        }
        //Moscow
        else if (song_name == "Nutcracker Suite" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[25])
        {
            song_name = "Nutcracker Suite by Tchaikovsky";
            message = "Now that you are part of the big leagues and have commanded world wide recognition, you must now play super long songs.  This one shall be your first.  Good luck.";
            currentSong = "Nutcracker1";
            scene = "moscow";
            validSong = true;
        }
        //Paris
        //Unfortunately there were no midi files of Rite of Spring that actually worked so I had to resort to a lesser known (and probably easier piece to take its spot... oh well...
        else if (song_name == "Nocturnes" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[26])
        {
            song_name = "Nocturnes: Fetes by Claude Debussy";
            message = "You are now all the rage in Paris.  Play them this energetic classic by Debussy and gain world fame in one of the biggest art capitols in the world.";
            currentSong = "Nocturnes";
            scene = "paris";
            validSong = true;
        }
        //Sanfrancisco
        else if (song_name == "Rhapsody in Blue" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[27])
        {
            song_name = "Rhapsody in Blue by George Gershwin";
            message = "Welcome to the jazz age.  Jazz has suddenly gained a surge of popularity in America (probably because Trump accidentally poisoned the drinking water and this is merely a side effect).  Play this difficult jazz classic and America will make you a star!";
            currentSong = "RhapsodyInBlue";
            scene = "sanFrancisco";
            validSong = true;
        }
        //Moscow
        else if (song_name == "Flight of the Bumblebee" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[28])
        {
            song_name = "Flight of the Bumblebee by Rimsky-Korsakov";
            message = "You have captured the hearts of the Americans and French but the Russians still don't think you are worth anything.  Play this impossible piece and Russia will crown you the ultimate conductor.  But fail this one time, and you will come crashing down. GOOD LUCK SUCKA!";
            currentSong = "FlightOfTheBumblebee";
            scene = "moscow";
            validSong = true;
        }
        //Hellportal
        else if (song_name == "Night on Bald Mountain" && GlobalVariables.storyMode && GlobalVariables.unlockedLevels[29])
        {
            song_name = "Night on Bald Mountain by Mussorgsky";
            message = "You have proven your worth.  Now you shall have a playoff against the devil.  If you can beat his song, he will give you whatever your heart desires.  Fail, and the devil gets your soul.  Fame often comes at a price!  THIS IS IT!  THE FINAL LEVEL!  WOOHOO!";
            currentSong = "NightOnBaldMountain";
            scene = "hellPortal";
            validSong = true;
        }
        else if (GlobalVariables.storyMode)
        {
            message = "The song that you have chosen hasn't been unlocked.  Please play previous levels before selecting this one.";
            song_name = "Song Locked";
            validSong = false;
        }


        else if (song_name == "Mary Had a Little Lamb" && !GlobalVariables.storyMode)
        {
            message = "You are Forté Pianissimo, a poor and hapless bum who has a dream of one day becoming a great composer.  Throughout the years of living on the streets, generous donors have given you in total $5000, enough to start a small orchestra.  You have decided to put on a street performance in the alley where you frequent.  Perhaps this is the start of something new?";
            currentSong = "MaryHadALittleLamb";
            validSong = true;
        }
        else if (song_name == "Fur Elise" && !GlobalVariables.storyMode)
        {
            currentSong = "FurElise";
            validSong = true;
        }
        else if (song_name == "In the Hall of the Mountain King" && !GlobalVariables.storyMode)
        {
            currentSong = "InTheHallOfTheMountainKing";
            validSong = true;
        }
        else if (song_name == "Eine Kleine Nachtmusik" && !GlobalVariables.storyMode)
        {
            currentSong = "EineKleineNachtmusik";
            validSong = true;
        }
        else if (song_name == "Canon in D" && !GlobalVariables.storyMode)
        {
            currentSong = "CanonInD";
            validSong = true;
        }
        else if (song_name == "Sabre Dance" && !GlobalVariables.storyMode)
        {
            currentSong = "SabreDance";
            validSong = true;
        }
        else if (song_name == "5th Symphony First Movement" && !GlobalVariables.storyMode)
        {
            currentSong = "5thSymphony";
            validSong = true;
        }
        else if (song_name == "Moonlight Sonata" && !GlobalVariables.storyMode)
        {
            currentSong = "MoonlightSonata1";
            validSong = true;
        }
        else if (song_name == "Ave Maria" && !GlobalVariables.storyMode)
        {
            currentSong = "AveMaria";
            validSong = true;
        }
        else if (song_name == "Toccata in Fugue" && !GlobalVariables.storyMode)
        {
            currentSong = "ToccataInFugue";
            validSong = true;
        }
        else if (song_name == "Pomp and Circumstance" && !GlobalVariables.storyMode)
        {
            currentSong = "PompAndCircumstance";
            validSong = true;
        }
        else if (song_name == "Bolero" && !GlobalVariables.storyMode)
        {
            currentSong = "Bolero";
            validSong = true;
        }
        else if (song_name == "Erlkonig" && !GlobalVariables.storyMode)
        {
            currentSong = "Erlkonig";
            validSong = true;
        }
        else if (song_name == "O Fortuna" && !GlobalVariables.storyMode)
        {
            currentSong = "OFortuna";
            validSong = true;
        }
        else if (song_name == "Carmen" && !GlobalVariables.storyMode)
        {
            currentSong = "CarmenHabanera";
            validSong = true;
        }
        else if (song_name == "Mars" && !GlobalVariables.storyMode)
        {
            currentSong = "Mars";
            validSong = true;
        }
        else if (song_name == "Peter and the Wolf" && !GlobalVariables.storyMode)
        {
            currentSong = "PeterAndTheWolf";
            validSong = true;
        }
        else if (song_name == "Ride of the Valkyries" && !GlobalVariables.storyMode)
        {
            currentSong = "RideOfTheValkyries";
            validSong = true;
        }
        else if (song_name == "Blue Danube Waltz" && !GlobalVariables.storyMode)
        {
            currentSong = "BlueDanubeWaltz";
            validSong = true;
        }
        else if (song_name == "Sorcerer's Apprentice" && !GlobalVariables.storyMode)
        {
            currentSong = "SorcerersApprentice";
            validSong = true;
        }
        else if (song_name == "Ode to Joy" && !GlobalVariables.storyMode)
        {
            currentSong = "OdeToJoy";
            validSong = true;
        }
        else if (song_name == "William Tell Overture" && !GlobalVariables.storyMode)
        {
            currentSong = "WilliamTellOverture";
            validSong = true;
        }
        else if (song_name == "Infernal Galop" && !GlobalVariables.storyMode)
        {
            currentSong = "CanCan";
            validSong = true;
        }
        else if (song_name == "Funeral March" && !GlobalVariables.storyMode)
        {
            currentSong = "FuneralMarch";
            validSong = true;
        }
        else if (song_name == "Turkish March" && !GlobalVariables.storyMode)
        {
            currentSong = "Turkish March";
            validSong = true;
        }
        else if (song_name == "Nutcracker Suite" && !GlobalVariables.storyMode)
        {
            currentSong = "Nutcracker1";
            validSong = true;
        }
        else if (song_name == "Nocturnes" && !GlobalVariables.storyMode)
        {
            currentSong = "Nocturnes";
            validSong = true;
        }
        else if (song_name == "Rhapsody in Blue" && !GlobalVariables.storyMode)
        {
            currentSong = "RhapsodyInBlue";
            validSong = true;
        }
        else if (song_name == "Flight of the Bumblebee" && !GlobalVariables.storyMode)
        {
            currentSong = "FlightOfTheBumblebee";
            validSong = true;
        }
        else if (song_name == "Night on Bald Mountain" && !GlobalVariables.storyMode)
        {
            currentSong = "NightOnBaldMountain";
            validSong = true;
        }
        if (GlobalVariables.storyMode) {
            songName = GameObject.FindGameObjectWithTag("songName").GetComponent<Text>();
            background = GameObject.FindGameObjectWithTag("backgroundInfo").GetComponent<Text>();
        }
        thisButton = GetComponent<Button>();
        thisButton.onClick.AddListener(() => setInfo());  // <-- you assign a method to the button OnClick event here
    }

    void setInfo()
    {
        Debug.Log(song_name);
        GlobalVariables.validSong = validSong;
        GlobalVariables.currentSong = currentSong;
        if (GlobalVariables.storyMode)
        {
            songName.text = song_name;
            background.text = message;
            GlobalVariables.currentBackground = scene;
        }
        
    }
}
