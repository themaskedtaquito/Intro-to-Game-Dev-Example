using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TextController : MonoBehaviour {
    string text;

    //event triggers
    bool distraction = false;
    bool stealattempt = false;
    bool hungry = false;
    bool shoplifted = false;
    bool accuser = false;
    bool fire = false;
    bool swing = false;
    bool THIEF = false;
    bool ready = false;
    bool conscience = false;
    int guilt = 0;
    int robin = 0;
    bool final = false;
    bool win = false;
    bool lose = false;
    bool needs = false;

    string art;

    public AudioSource crowd;
    public AudioSource nabbed;
    public GameObject map;
    List<string> choices = new List<string>();
    char a = 'a';
    char b = 'b';
    char c = 'c';

    int currentRoom = -1;

	void Start () {
       //populate list
       //It's dumb that one character strings are automatically type char and require more code to turn into strings
       choices.Add(a.ToString());
       choices.Add(b.ToString());
       choices.Add(c.ToString());
       text = "GALLERY THEFT\n\n\n\nYou're in the lobby of the art museum. Time to scout out the place for the perfect piece of art to steal. Press Space to enter the first exhibit, then use the arrow keys to navigate through the different galleries";
       //default state of rooms
        
	}

    // Update is called once per frame
    void Update()
    {

        if (THIEF == false) //Law Abiding Citizen mode
        {
            //Room Definitions
            if (currentRoom == -1)
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    currentRoom = 7;
                }
            }
            //Popart
            if (currentRoom == 8)
            {
                text = "Everything in here is quite modern. A drowning woman drawn in a comic book style, those stupid paintings of Campbell's tomato soup cans. This reminds you that you're very, very hungry.\n\nA. Steal the picture of the drowning woman\nB. Steal Campbell's Soup";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    art = "girl";
                    THIEF = true;
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    art = "soup";
                    THIEF = true;
                }
            }
            //Minimalist Art
            if (currentRoom == 7)
            {
                text = "Wow, the art in this room really blows. There is one painting that's literally just a blue square. Even you could make better art than that! Other gems include a red line cutting across a white background.There is one pretty piece called 'Composition II in Red, Blue, and Yellow' though...\n\nA. Steal the blue square painting\nB. Steal the painting with a red line\nC. Steal Composition II in Red, Blue, and Yellow\n\nSelect an option by pressing either 'a', 'b', or 'c'";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    art = "blue";
                    THIEF = true;
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    art = "red";
                    THIEF = true;
                }
                if (Input.GetKeyDown(KeyCode.C))
                {
                    art = "min";
                    THIEF = true;
                }
            }
            //Photography
            if (currentRoom == 6)
            {
                text = "The room is filled with photographs. Most of them seem to be done by the same artist. With the exact same subject matter. Who thought it would be a good idea to take 26 different photographs of just gas stations??\n\nA. Steal a photo of a gas station";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    art = "gas";
                    THIEF = true;
                }
            }
            //Impressionist Paintings
            if (currentRoom == 5)
            {
                text = "So this is where they hide the real art! You definitely recognize most of the paintings in this room, most of them done by Claude Monet. In fact, the entire Water Lilies series is on display.\n\nA. Steal one of the Water Lilies paintings.\n\nB. Attempt to steal the entire series";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    art = "lily";
                    THIEF = true;
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    art = "lilies";
                    THIEF = true;
                }
            }
            //Sculptures
            if (currentRoom == 4)
            {
                text = "Several statues greet you in this room. There is some bronze, including that guy who looks really deep in thought. Of course there is a marble statue of Aphrodite as well. What collection of sculptures would be complete without one?\n\nA. Steal The Thinker\nB. Steal Aphrodite";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    art = "think";
                    THIEF = true;
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    art = "greek";
                    THIEF = true;
                }
            }
            //Abstract Art
            if (currentRoom == 3)
            {
                text = "To your surprise, the art here is almost as bogus as that room with all the Minimalist stuff. There are no concrete forms, just abstract shapes. You look at one painting and feel as if you're staring into the void. In fact, the lack of form of all the pieces in this room make you feel as if you're falling into a void and your existence is insignificant.\n\nA. Steal an Abstract painting";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    art = "void";
                    THIEF = true;
                }
            }
            //Installation
            if (currentRoom == 2)
            {
                if (swing == true)
                {
                    text = "After telling the kid how awesome it would be to pretend to be Tarzan, swinging back and forth between the art dangling like vines from the ceiling, he actually did it! Now, several museum guards are trying to get him to stop. Now would be a good time to quietly slip away and take advantage of the distraction.";
                }
                else
                {
                    text = "This stuff might be a little hard to steal, but it sure is pretty to look at. Lots of shiny objects are hanging from the ceiling, creating shadows that dance across the walls. A young kid is staring up at the installation in awe.\n\nA. Try to convince the kid that swinging from the installation would be a grand idea";
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        distraction = true;
                        swing = true;
                    }
                }
            }
            //Gallery Giftshop
            if (currentRoom == 1)
            {
                text = "Hey look it's the gift shop! Most of the stuff here appears to be bags, shirts, etc. with the artwork printed on it and those lame souvenir cups. Generally unremarkable stuff.\n\nA. Attempt to shoplift something from the giftshop\nB. Accuse another customer of shoplifting";
                if (Input.GetKeyDown(KeyCode.A))
                {
                    shoplifted = true;
                    accuser = false;
                }
                if (Input.GetKeyDown(KeyCode.B))
                {
                    accuser = true;
                    shoplifted = false;
                }
            }
            //Gallery Cafe
            if (currentRoom == 0)
            {
                if (fire == true)
                {
                    text = "After you shouted 'FIRE' the entire place flew into a panic. People everywhere are screaming and the guards are trying to control the situation. Now would be a perfect time to take advantage of the chaos...";
                    
                    if (crowd.isPlaying== false)
                    {
                        crowd.Play();
                    }                   
                }
                else
                {
                    text = "You find yourself inside the museum's cafe. Indoors is the kitchen and ordering area. Most of the seating is outdoors on an open patio. You stop for a moment to breathe in some fresh air.\n\nA. Order some food\nB. Yell 'FIRE!' and panic the diners ";
                    if (Input.GetKeyDown(KeyCode.A))
                    {
                        hungry = true;
                    }
                    if (Input.GetKeyDown(KeyCode.B))
                    {
                        fire = true;
                        hungry = false;
                        distraction = true;
                    }
                }

            }

            //Room Navigation //rooms are laid out in a 3x3 grid
            if ((currentRoom < 6) && (Input.GetKeyDown(KeyCode.DownArrow)))
            {
                currentRoom += 3;
                stealattempt = false;
                hungry = false;
                accuser = false;
                shoplifted = false;
                crowd.Stop();
            }
            if ((currentRoom > 2) && (Input.GetKeyDown(KeyCode.UpArrow)))
            {
                currentRoom -= 3;
                stealattempt = false;
            }
            if ((currentRoom % 3 != 0) && (Input.GetKeyDown(KeyCode.LeftArrow)))
            {
                currentRoom -= 1;
                stealattempt = false;
                accuser = false;
                shoplifted = false;
            }
            if ((currentRoom % 3 != 2) && (Input.GetKeyDown(KeyCode.RightArrow)))
            {
                currentRoom += 1;
                stealattempt = false;
                hungry = false;
                accuser = false;
                shoplifted = false;
                crowd.Stop();
            }

            //steal paintings when the input is right
            if (currentRoom > 2)
            {
                if (choices.Contains(Input.inputString))
                {
                    if (distraction == false)
                    {
                        stealattempt = true;
                        THIEF = false;
                    }
                    else
                    {
                        nabbed.Play();
                        map.SetActive(false);
                    }
                }
            }
            if (currentRoom >= 0)
            {
                text += "\n\nUse the arrow keys to go check out a different room.";
            }

            //special scenarios otherwise text gets overwritten by previous room definitions
            if (stealattempt == true)
            {
                text += "\n\nThere are museum guards in this room. You might want to create some kind of distraction before trying to steal the art";
            }
            if (hungry == true)
            {
                text += "\n\nHahahaha just kidding. You're too poor to afford food from this overpriced cafe. That's why you're trying to pull off this heist, remember?";
            }
            if (shoplifted == true)
            {
                text += "\n\nWell now you've got yourself a nice little trinket, but that's still not going to pay the bills.";
            }
            if (accuser == true)
            {
                text += "\n\nYou tell one of the clerks that a random passerby was trying to shoplift. To your surprise, they actually were trying to steal a keychain! The clerk thanks you and goes back to work.";
            }
        }
        else
        { //CRIMINAL MASTERMIND MODE
            //Art definitions
            if (art == "girl")
            {
                text = "You stole the picture of a girl who is drowning. A 'Drowning Girl' if you will. You're not really sure how much it's worth, but it's gotta be a good chunk of change at least";
            }
            if (art == "soup")
            {
                text = "This is the piece that started a genre. Incredible, is it not? This.. This Campbell's Tomato Soup can. Right. A bit silly, but hey, it will definitely sell for a lot of money.";
            }
            if (art == "blue")
            {
                text = "Nice! You stole the blue square. You're not entirely sure why this is considered art, but you're certain that you'll find some idiot buyer.";
            }
            if (art == "red")
            {
                text = "You are the proud owner of a white canvas with a red line cutting through it. Hopefully you'll soon transfer ownership and be the proud owner of a lot of money.";
            }
            if (art == "min")
            {
                text = "This oddly neat arrangement of red, white, blue, and yellow squares seems familiar... Must mean that it is relatively famous and thus worth a relatively high amount.";
            }
            if (art == "gas")
            {
                text = "To be honest, this single photograph of a gas station is indistinguishable from the other 25. I bet the artists cherishes every gas station to the point that he would buy the art back from you though.";
            }
            if (art == "void")
            {
                text = "You steal the painting. You look into the void. The void looks into you. The void understands you, intimately. You are almost tempted not to sell this painting, to keep it for yourself, but you snap out of it.";
            }
            if (art == "think")
            {
                text = "Wow. I can't believe you actually stole a statue. Honestly, props to you. This thing is made of bronze and ridiculously heavy. Seriously, how did you do it? I guess it doesn't matter how you stole it as long as you can sell it...";
            }
            if (art == "greek")
            {
                text = "So you stole Aphrodite. Would you say she's the most beautiful Greek Goddess? Don't answer that, we don't need another Trojan War.";
            }
            if (art == "lily")
            {
                text = "This Water Lilies here is a real work of art. Honestly the best choice you could have made, this piece's value is most definitely assured.";
            }
            if (art == "lilies")
            {
                text = "Every single painting in the series? As they say, go big or go home. I like the cut of your jib, though to consider something like this, you might have to be three sheets to the wind. Regardless, with this haul you'll be set for life"; //no, nautical references are not relevant. I just like sailing.
            }
            //The Final Boss
            if (ready == false)
            {
                text += "\n\nNow that you've secured the artwork, you should make your escape. The best bet is probably to head out the cafe's outdoors patio. But first, there's one more obstacle that you have to face.\n\nA.What is the last obstacle?";
                if (Input.GetKeyDown(KeyCode.A)){
                    ready = true;
                }
            }
            else
            {
                if (conscience == false)
                {
                    text = "Your conscience\n\nA. My conscience?\nB. I don't have a conscience";
                    if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B))
                    {
                        conscience = true;
                    }
                }
               else if(conscience == true) //conversation with conscience
                {
                    text = "I'm your conscience. Don't you feel bad about stealing?\n\nA. No, not really\nB. Yeah, a little bit";
                    if (guilt == 1)
                    {
                        text = "Didn't your parents ever teach you that stealing is wrong?\n\nA. Yes...\nB. Haven't you heard of people like Robin Hood and Aladdin?";
                        if (robin == 2)
                        {
                            text = "Yeah, yeah. Rich people have more ought to provide for those with less, and if they aren't willing to we will force them. Off with their heads!\n\nA. Yes! Exactly!\nB. Well, perhaps not so violently, but yes";
                            if (final == false)
                            {
                                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.B))
                                {
                                    final = true;
                                }
                            }

                            else if (final == true)
                            {
                                text = "So you've finally overcome your conscience then?\n\nA. Yes. Let's steal this art and get out of here\nB. I still feel a little guilty about it";
                                if (Input.GetKeyDown(KeyCode.Space))
                                {
                                    Debug.Log("I'm really trying here");
                                }
                                if (Input.GetKeyDown(KeyCode.A))
                                {
                                    win = true;
                                }
                                if (Input.GetKeyDown(KeyCode.B))
                                {
                                    Debug.Log("You pressed B");
                                    guilt = 2;
                                    needs = true;
                                    final = false;
                                }
                            }
                        }
                        else if (Input.GetKeyDown(KeyCode.A))
                        {
                            robin = 1;
                            guilt = 2;
                        }
                        
                        else if (Input.GetKeyDown(KeyCode.B))
                        {
                            robin = 2;
                        }
                    }
                    else if (guilt == 2)
                    {
                        text = "So you agree with me, your conscience, that this is a bad idea and we shouldn't steal?\n\nA You're right. I can't compromise my morals just because I've fallen on hard times. I'll return the art.\nB. Yes, but I really, really need the money.";
                        if (needs == true)
                        {
                            text = "You're going to have to ask yourself one last question then. Is having a roof over your head and food in your stomach more important than following the rule of law that holds society together?\n\nA. No, it isn't. if we do not follow the law we have broken the social contract that exists between the governer and the governed. I suppose I ought to return the art...\nB. Yes, of course it is. How valid can this rule of law be when it has failed me and so many others in my position?";
                            if (Input.GetKeyDown(KeyCode.A))
                            {
                                lose = true;
                            }
                            else if (Input.GetKeyDown(KeyCode.B))
                            {
                                guilt = 1;
                                final = true;
                                robin = 2;
                                
                            }
                        }
                        if (Input.GetKeyDown(KeyCode.A))
                        {
                            lose = true;
                        }
                        else if (Input.GetKeyDown(KeyCode.B))
                        {
                            needs = true;
                        }
                        
                    }
                    else if (Input.GetKeyDown(KeyCode.A))
                    {
                        guilt = 1;
                    }
                    else if (Input.GetKeyDown(KeyCode.B))
                    {
                        guilt = 2;
                    }       
                }
            }
        }
        if (win == true)
        {
            text = "You have overcome your conscious, a capitalist society's expectations, and some stupid museum guards. After making off with some precious art, you return home and go about selling it on the black market. With the money, you live comfortably for a while. Your life becomes stable enough that you're able to land a decent paying job, working from 9-5. You go to work, you pay taxes, you can afford a house and food. You're happy, but can't quite shake the feeling that you've sold out to the man.\n\nTHE END\n Press SPACE to play again";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
        if (lose == true)
        {
            text = "You're a good person. Your conscience is proud of you for doing the right thing. You're still quite poor, you don't know what you're going to eat for dinner, and rent is due in two days. But things could be worse, right? Right??\n\n\n\nTHE END\n Press SPACE to play again";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
        GetComponent<Text>().text = text;
        
    }
}
