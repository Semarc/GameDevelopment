using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum Conditions
{
	LostAusruestung,
	FoundAusruestung,
	Archive,
	IceSampleInspected,
	DataAnalyzed,
	LookedForAusrustung
}

public class ConversationManager : MonoBehaviour
{
	public Dictionary<Conditions, bool> MyConditions = new()
	{
		{Conditions.LostAusruestung, false },
		{Conditions.FoundAusruestung, false },
		{Conditions.Archive, false },
		{Conditions.IceSampleInspected, false },
		{Conditions.DataAnalyzed, false },
		{Conditions.LookedForAusrustung, false },
	};
	public int StudyCount { get; set; } = 0;

	[SerializeField] private List<TMP_Text> ConversationButtons;
	[SerializeField] private TMP_Text ConversationText;
	[SerializeField] private Image GameLocationImage;
	[SerializeField] private Sprite[] BackgroundImages;

	private ConversationNode CurrentConversationNode;
	private bool BackToMainMenu = false;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < ConversationButtons.Count; i++)
		{
			int i1 = i;

			EventTrigger trigger = ConversationButtons[i].GetComponent<EventTrigger>();
			EventTrigger.Entry entry = new()
			{
				eventID = EventTriggerType.PointerDown
			};
			entry.callback.AddListener((data) => OnConversationClick(i1));
			trigger.triggers.Add(entry);
		}
		CurrentConversationNode = ConversationTreeStart();
		SetConversationStuff();
		AudioScript.Instance.PlayVorDerStationSound();
	}

	public void OnConversationClick(int ConversationOption)
	{
		if (BackToMainMenu)
		{
			SceneManager.LoadScene(0);
		}
		if (ConversationOption < CurrentConversationNode.conversationAnswers.Count && CurrentConversationNode.conversationAnswers[ConversationOption].Condition())
		{
			CurrentConversationNode = CurrentConversationNode.SelectAnswer(ConversationOption);

			AudioScript.Instance.PlaySelectSound();

			SetConversationStuff();
		}
	}

	public void SetConversationStuff()
	{
		ConversationText.text = CurrentConversationNode.Question;
		GameLocationImage.sprite = CurrentConversationNode.GameLocation.BackgroundImage;
		for (int i = 0; i < ConversationButtons.Count; i++)
		{
			ConversationButtons[i].text = i < CurrentConversationNode.conversationAnswers.Count && CurrentConversationNode.conversationAnswers[i].Condition()
				? CurrentConversationNode.conversationAnswers[i].Answer
				: string.Empty;
		}

		Debug.Log("Current Location: " + CurrentConversationNode.GameLocation.Name);

		if (CurrentConversationNode.GameLocation.ForeGround)
		{
			ConversationButtons[0].text = "Go Back To Main Menu";
			BackToMainMenu = true;
		}
	}



	public ConversationNode ConversationTreeStart()
	{
		GameLocation OnPlane                =  new(BackgroundImages[0], "OnPlane");
		GameLocation LandedPlane            =  new(BackgroundImages[1], "LandedPlane");
		GameLocation FreezeToDeath          =  new(BackgroundImages[3], "FreezeToDeath", true);
		GameLocation Eingangsraum           =  new(BackgroundImages[4], "Eingangsraum");
		GameLocation YourRoom               =  new(BackgroundImages[5], "YourRoom");
		GameLocation Lab                    =  new(BackgroundImages[6], "Lab");
		GameLocation OverStudied            =  new(BackgroundImages[7], "OverStudied", true);
		GameLocation Garage                 =  new(BackgroundImages[8], "Garage");
		GameLocation OnTheWay               =  new(BackgroundImages[9], "OnTheWay");
		GameLocation BabyIceBear            =  new(BackgroundImages[10], "BabyIceBear");
		GameLocation KilledByMamaIceaBear   =  new(BackgroundImages[11], "BabyIceBear", true);
		GameLocation OnGlacier              =  new(BackgroundImages[12], "OnGlacier");
		GameLocation GlacierExploded        =  new(BackgroundImages[12], "GlacierExploded", true);
		GameLocation GlacierWeWillSee       =  new(BackgroundImages[12], "GlacierWeWillSee", true);
		GameLocation GlacierCollapsed       =  new(BackgroundImages[12], "GlacierCollapsed", true);



		ConversationNode OnPlaneStart                           = new("Welcome on board the A-537, the Arctic Expedition flight to Station Peak on the mission to investigate the danger of Glacier Aurora collapsing and endangering the surpassing of the Waterway below as well as causing a tidal wave that will destroy the Outpost for underwater research one hundred miles north.\r\nThe newest observations on data about the stability of Glacier Aurora have reached us and are highly alarming, which is why a expert was send to examine the situation. \r\nYou are said expert and soon your team and you will arrive at the Station to lead further investigations. But time is ticking, if the observations were true you might only have 24 hours before disaster strikes. Let's hope you are fast enough to collect information and plan further actions, in worst case a controlled detonation is still better then the total collapse.\r\n", OnPlane);

		ConversationNode LandedPlaneNodeFromOnPlane             = new("You fly right into the storm. Lucky for you your pilot was a stunt pilot once and can therefore manage to meander through and a successful emergency landing right next to the station \r\nSadly your plain gets damaged alongside with parts of your equipment\r\n"                         , LandedPlane);

		ConversationNode FreezeToDeathFromLandedSafely          = new("You walk right into a raging snow storm, very smart move. We appreciate your strong will to start the research but sadly you freeze to death before you can even get close to the station."       , FreezeToDeath);

		ConversationNode EingangsraumFromOnPlane                = new("Good call, we've landed safely. Flying to the station could have gone very wrong if I look at the storm over there. What now?"               , Eingangsraum);
		ConversationNode EingangsraumFromLandedPlane            = new($"Ah the sky is clearing. Finally! This took quite a while especially since we're already so short on time. Let's get going so we can get to the station as fast as possible and start the research. {System.Environment.NewLine} Welcome to entry hall of the Station Peak! Where are you heading?"         , Eingangsraum);
		ConversationNode EingangsraumFromYourRoom               = new("Welcome to entry hall of the Station Peak! Where are you heading?"            , Eingangsraum);
		ConversationNode EingangsraumFromLab                    = new("Welcome to entry hall of the Station Peak! Where are you heading?"                 , Eingangsraum);
		ConversationNode EingangsraumFromGarage                 = new("Welcome to entry hall of the Station Peak! Where are you heading?"              , Eingangsraum);

		ConversationNode YourRoomFromEingangsraum               = new("This is your room that the team of the station provided for you. "                            , YourRoom);
		ConversationNode YourRoomFromLookingForEquipmentFail    = new("Seems like you've lost quite a lot of equipment during the landing, let's hope you can still do your research properly "                            , YourRoom);
		ConversationNode YourRoomFromLookingForEquipmentSuccess = new("You found some of your equipment. This will be helpful for research "                            , YourRoom);

		ConversationNode LabFromEingangsraum                    = new("This is station Pieks Lab. There's lots of funny science stuff everywhere. As you are a great professional you hold back from touching it all "                 , Lab);
		ConversationNode LabFromArchive                         = new("Wow this is really cool! It's about polar bears! You love polar bears! And so interesting- Ahem nonono you're not here to look at that, you're a professional! But,,, polar bear studies-"                      , Lab);
		ConversationNode OverStudiedFromLab                     = new("You keep looking for more and get investigated. But somehow you forget the time over it and spend hours on completely irrelevant stuff. Glacier Aurora may have collapsed by now but hey you now know all about polar bears!"                 , OverStudied);
		ConversationNode LabFromAnalyzeData                     = new("You've made some interesting observations that will definitely help you at the glacier!"                  , Lab);
		ConversationNode LabFromInspectIceSample                = new("You've made some interesting observations that will definitely help you at the glacier!"             , Lab);

		ConversationNode GarageFromEingangsraum                 = new("This is the stations garage. You can see the snowmobiles that you will use to get to glacier Aurora. You can start the expedition whenever you feel ready. Just be aware that once you leave you won't be able to come back in time, so if you want to do some further investigations do that first."              , Garage);

		ConversationNode OnTheWayFromGarage                     = new("You get your and the station team ready and head of towards aurora. What now?"                  , OnTheWay);
		ConversationNode OnTheWayFromBabyIceBear                = new("You returned to the patch from the Icebears"             , OnTheWay);

		ConversationNode BabyIceBearFromOnTheWay                = new("You watch the baby and his mom who appeared a moment later and take a really cute picture that you can show your friends later"             , BabyIceBear);
		ConversationNode BabyIceBearFromWait                    = new("BabyIceBearFromWait"          , BabyIceBear);

		ConversationNode KilledByMamaFromBabyIceBear            = new("As you went too close to the baby polar bear the mom showed up and smacked you our of existence. Don't blame her, if I had a child I wouldn't have trusted you with it either."         , KilledByMamaIceaBear);

		ConversationNode OnGlacierFromOnTheWayMustBeExploded    = new("You reached glacier Aurora. Time to take a closer look at the scene in front of you and to form a plan" , OnGlacier);
		ConversationNode OnGlacierFromOnTheWayWeWillSee         = new("You reached glacier Aurora. Time to take a closer look at the scene in front of you and to form a plan"      , OnGlacier);
		ConversationNode OnGlacierFromOnTheWayWillCollapse      = new("You reached glacier Aurora. Time to take a closer look at the scene in front of you and to form a plan"   , OnGlacier);

		ConversationNode GlacierCollapsedNode                   = new("As you didn't see the need to investigate further, you have nearly no information, which is why you can only watch as Glacier Aurora crashes into the deep canyon below. Let's just hope the station team could warn everyone in time and the outpost down the stream got evacuated in time. "                , GlacierCollapsed);
		ConversationNode GlacierExplodedNode                    = new("As you didn't research as much as you could have you don't know how to safe the glacier. However you can try and know how to lead a controlled detonation if the situation gets too dangerous."                 , GlacierExploded);
		ConversationNode GlacierWeWillSeeNode                   = new("As you've done all your research and arived in time you can secure the glacier. It gives you and the team enough time to make a failsafe plan qnd communicate with other professionals to make sure there will not be any danger of Glacier Aurora collapsing in the future. Great job!"                    , GlacierWeWillSee);



		OnPlaneStart.conversationAnswers.Add(new(LandedPlaneNodeFromOnPlane, "Land now"));
		OnPlaneStart.conversationAnswers.Add(new(EingangsraumFromOnPlane, "Fly to station", selectFunc: () => { MyConditions[Conditions.LostAusruestung] = true; AudioScript.Instance.PlayInDerStationSound(); }));


		LandedPlaneNodeFromOnPlane.conversationAnswers.Add(new(EingangsraumFromOnPlane, "Wait until the storm is over", selectFunc: () => AudioScript.Instance.PlayInDerStationSound()));
		LandedPlaneNodeFromOnPlane.conversationAnswers.Add(new(FreezeToDeathFromLandedSafely, "Start walking to the station"));


		List<ConversationAnswer> EingangsroomAnswers = new(){new(YourRoomFromEingangsraum, "Go to your Room"),
															 new(LabFromEingangsraum, "Go to the Lab"),
															 new(GarageFromEingangsraum, "Go to the Garage")};
		EingangsraumFromOnPlane.conversationAnswers =
		EingangsraumFromLandedPlane.conversationAnswers =
		EingangsraumFromYourRoom.conversationAnswers =
		EingangsraumFromLab.conversationAnswers =
		EingangsraumFromGarage.conversationAnswers = EingangsroomAnswers;


		List<ConversationAnswer> YourRoomAnswers = new(){new(YourRoomFromLookingForEquipmentFail, "Search through the bags", () => MyConditions[Conditions.Archive] == true && MyConditions[Conditions.LookedForAusrustung] == false, () => MyConditions[Conditions.LookedForAusrustung] = true),
														 new(YourRoomFromLookingForEquipmentSuccess, "Search through the bags", () => MyConditions[Conditions.Archive] == false && MyConditions[Conditions.LookedForAusrustung] == false, () => MyConditions[Conditions.LookedForAusrustung] = true),
														 new(EingangsraumFromYourRoom, "Go back to the Entry Hall")};
		YourRoomFromEingangsraum.conversationAnswers =
		YourRoomFromLookingForEquipmentFail.conversationAnswers =
		YourRoomFromLookingForEquipmentSuccess.conversationAnswers = YourRoomAnswers;



		List<ConversationAnswer> LabAnswers = new(){ new(LabFromArchive, "Go investigate the cool science stuff",() => MyConditions[Conditions.Archive] == false, () => {MyConditions[Conditions.Archive] = true; }),
													 new(OverStudiedFromLab, "Look further into the Ice bears", () => MyConditions[Conditions.Archive] == true),
													 new(LabFromAnalyzeData, "Research your case ", selectFunc: () => MyConditions[Conditions.DataAnalyzed] = true),
													 new(LabFromInspectIceSample, "Take a closer look at Auroras ice structure ", () => MyConditions[Conditions.FoundAusruestung] == true, () => MyConditions[Conditions.IceSampleInspected] = true),
													 new(EingangsraumFromLab, "Go back to the Entry Hall")};
		LabFromEingangsraum.conversationAnswers =
		LabFromArchive.conversationAnswers =
		LabFromAnalyzeData.conversationAnswers =
		LabFromInspectIceSample.conversationAnswers = LabAnswers;


		GarageFromEingangsraum.conversationAnswers.Add(new(OnTheWayFromGarage, "Leave for the expedition", selectFunc: () => AudioScript.Instance.PlayNachDerStationSound()));
		GarageFromEingangsraum.conversationAnswers.Add(new(EingangsraumFromGarage, "Go back to the Entry Hall"));


		List<ConversationAnswer> OnTheWayAnswers = new(){new(BabyIceBearFromOnTheWay, "Go look for polar bears"),
														 new(OnGlacierFromOnTheWayMustBeExploded, "Get to the glacier as fast as possible", () => MyConditions[Conditions.IceSampleInspected] ^ MyConditions[Conditions.DataAnalyzed]),
														 new(OnGlacierFromOnTheWayWeWillSee, "Get to the glacier as fast as possible", () => MyConditions[Conditions.IceSampleInspected] && MyConditions[Conditions.DataAnalyzed]),
														 new(OnGlacierFromOnTheWayWillCollapse, "Get to the glacier as fast as possible", () => MyConditions[Conditions.IceSampleInspected] == false && MyConditions[Conditions.DataAnalyzed] == false)};
		OnTheWayFromGarage.conversationAnswers =
		OnTheWayFromBabyIceBear.conversationAnswers = OnTheWayAnswers;

		List<ConversationAnswer> BabyIceBearAnswers = new(){new(OnTheWayFromBabyIceBear, "Continue expedition"),
															new(BabyIceBearFromWait, "Just Watch"),
															new(KilledByMamaFromBabyIceBear, "Go closer ")};


		BabyIceBearFromOnTheWay.conversationAnswers =
		BabyIceBearFromWait.conversationAnswers = BabyIceBearAnswers;

		OnGlacierFromOnTheWayMustBeExploded.conversationAnswers.Add(new(GlacierExplodedNode, "Investigate"));

		OnGlacierFromOnTheWayWeWillSee.conversationAnswers.Add(new(GlacierWeWillSeeNode, "Investigate"));

		OnGlacierFromOnTheWayWillCollapse.conversationAnswers.Add(new(GlacierCollapsedNode, "Investigate"));


		return OnPlaneStart;
	}
}