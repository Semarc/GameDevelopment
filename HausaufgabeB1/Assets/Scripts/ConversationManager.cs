using System.Collections.Generic;

using TMPro;

using UnityEngine;
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

	[SerializeField] private List<Button> ConversationButtons;
	[SerializeField] private TMP_Text ConversationText;
	[SerializeField] private Image GameLocationImage;
	[SerializeField] private Sprite[] BackgroundImages;

	ConversationNode CurrentConversationNode;

	// Start is called before the first frame update
	void Start()
	{
		for (int i = 0; i < ConversationButtons.Count; i++)
		{
			int i1 = i;
			ConversationButtons[i].onClick.AddListener(() => OnConversationClick(i1));
		}
		CurrentConversationNode = ConversationTreeStart();
		SetConversationStuff();
	}

	public void OnConversationClick(int ConversationOption)
	{
		CurrentConversationNode = CurrentConversationNode.SelectAnswer(ConversationOption);
		SetConversationStuff();
	}

	public void SetConversationStuff()
	{
		ConversationText.text = CurrentConversationNode.Question;
		GameLocationImage.sprite = CurrentConversationNode.GameLocation.BackgroundImage;
		for (int i = 0; i < ConversationButtons.Count; i++)
		{
			if (i < CurrentConversationNode.conversationAnswers.Count && CurrentConversationNode.conversationAnswers[i].Condition())
			{
				ConversationButtons[i].gameObject.SetActive(true);
				ConversationButtons[i].enabled = true;
				ConversationButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = CurrentConversationNode.conversationAnswers[i].Answer;
			}
			else
			{
				ConversationButtons[i].enabled = false;
				ConversationButtons[i].gameObject.SetActive(false);
			}
		}
	}



	public ConversationNode ConversationTreeStart()
	{
		GameLocation OnPlane                =  new(BackgroundImages[0], "OnPlane");
		GameLocation LandedPlane            =  new(BackgroundImages[0], "LandedPlane");
		GameLocation FreezeToDeath          =  new(BackgroundImages[0], "FreezeToDeath", true);
		GameLocation Eingangsraum           =  new(BackgroundImages[0], "Eingangsraum");
		GameLocation YourRoom               =  new(BackgroundImages[0], "YourRoom");
		GameLocation OverSlept              =  new(BackgroundImages[0], "OverSlept", true);
		GameLocation Lab                    =  new(BackgroundImages[0], "Lab");
		GameLocation OverStudied            =  new(BackgroundImages[0], "OverStudied", true);
		GameLocation Garage                 =  new(BackgroundImages[0], "Garage");
		GameLocation OnTheWay               =  new(BackgroundImages[0], "OnTheWay");
		GameLocation BabyIceBear            =  new(BackgroundImages[0], "BabyIceBear");
		GameLocation KilledByMamaIceaBear   =  new(BackgroundImages[0], "BabyIceBear", true);
		GameLocation OnGlacier              =  new(BackgroundImages[0], "OnGlacier");
		GameLocation GlacierExploded        =  new(BackgroundImages[0], "GlacierExploded", true);
		GameLocation GlacierWeWillSee       =  new(BackgroundImages[0], "GlacierWeWillSee", true);
		GameLocation GlacierCollapsed       =  new(BackgroundImages[0], "GlacierCollapsed", true);



		ConversationNode OnPlaneStart                           = new("Welcome on board the A-537, the Arctic Expedition flight to Station Peak on the mission to investigate the danger of Glacier Aurora collapsing and endangering the surpassing of the Waterway below as well as causing a tidal wave that will destroy the Outpost for underwater research one hundred miles north.\r\nThe newest observations on data about the stability of Glacier Aurora have reached us and are highly alarming, which is why a expert was send to examine the situation. \r\nYou are said expert and soon your team and you will arrive at the Station to lead further investigations. But time is ticking, if the observations were true you might only have 24 hours before disaster strikes. Let's hope you are fast enough to collect information and plan further actions, in worst case a controlled detonation is still better then the total collapse.\r\n", OnPlane);

		ConversationNode LandedPlaneNodeFromOnPlane             = new("LandedPlane"                         , LandedPlane);

		ConversationNode FreezeToDeathFromLandedSafely          = new("FreezeToDeathFromLandedSafely"       , FreezeToDeath);

		ConversationNode EingangsraumFromOnPlane                = new("EingangsraumFromPlane"               , Eingangsraum);
		ConversationNode EingangsraumFromLandedPlane            = new("EingangsraumFromLandedPlane"         , Eingangsraum);
		ConversationNode EingangsraumFromYourRoom               = new("EingangsraumFromYourRoom"            , Eingangsraum);
		ConversationNode EingangsraumFromLab                    = new("EingangsraumFromLab"                 , Eingangsraum);
		ConversationNode EingangsraumFromGarage                 = new("EingangsraumFromGarage"              , Eingangsraum);

		ConversationNode YourRoomFromEingangsraum               = new("YourRoom"                            , YourRoom);
		ConversationNode YourRoomFromSleeping                   = new("YourRoom"                            , YourRoom);
		ConversationNode YourRoomFromLookingForEquipmentFail    = new("YourRoom"                            , YourRoom);
		ConversationNode YourRoomFromLookingForEquipmentSuccess = new("YourRoom"                            , YourRoom);

		ConversationNode LabFromEingangsraum                    = new("LabFromEingangsraum"                 , Lab);
		ConversationNode LabFromArchive                         = new("LabFromArchive"                      , Lab);
		ConversationNode LabFromIceBearStudy                    = new("LabFromIceBearStudy"                 , Lab);
		ConversationNode LabFromAnalyzeData                     = new("LabFromAnalyzeData"                  , Lab);
		ConversationNode LabFromInspectIceSample                = new("LabFromInspectIceSample"             , Lab);

		ConversationNode GarageFromEingangsraum                 = new("GarageFromEingangsraum"              , Garage);

		ConversationNode OnTheWayFromGarage                     = new("OnTheWayFromGarage"                  , OnTheWay);
		ConversationNode OnTheWayFromBabyIceBear                = new("OnTheWayFromBabyIceBear"             , OnTheWay);

		ConversationNode BabyIceBearFromOnTheWay                = new("BabyIceBearFromOnTheWay"             , BabyIceBear);
		ConversationNode BabyIceBearFromTakePicture             = new("BabyIceBearFromTakePicture"          , BabyIceBear);

		ConversationNode KilledByMamaFromBabyIceBear            = new("KilledByMamaFromBabyIceBear"         , KilledByMamaIceaBear);

		ConversationNode OnGlacierFromOnTheWayMustBeExploded    = new("OnGlacierFromOnTheWayMustBeExploded" , OnGlacier);
		ConversationNode OnGlacierFromOnTheWayWeWillSee         = new("OnGlacierFromOnTheWayWeWillSee"      , OnGlacier);
		ConversationNode OnGlacierFromOnTheWayWillCollapse      = new("OnGlacierFromOnTheWayWillCollapse"   , OnGlacier);

		ConversationNode GlacierExplodedNode                    = new("GlacierExplodedNode"                 , GlacierExploded);
		ConversationNode GlacierWeWillSeeNode                   = new("GlacierSafedNode"                    , GlacierWeWillSee);
		ConversationNode GlacierCollapsedNode                   = new("GlacierCollapsedNode"                , GlacierCollapsed);



		OnPlaneStart.conversationAnswers.Add(new(LandedPlaneNodeFromOnPlane, "Land"));
		OnPlaneStart.conversationAnswers.Add(new(EingangsraumFromOnPlane, "FlyToStation", selectFunc: () => MyConditions[Conditions.LostAusruestung] = true));


		LandedPlaneNodeFromOnPlane.conversationAnswers.Add(new(EingangsraumFromOnPlane, "Wait"));
		LandedPlaneNodeFromOnPlane.conversationAnswers.Add(new(FreezeToDeathFromLandedSafely, "Go Now"));


		List<ConversationAnswer> EingangsroomAnswers = new(){new(YourRoomFromEingangsraum, "GoToCabin"),
															 new(LabFromEingangsraum, "GoToLab"),
															 new(GarageFromEingangsraum, "GoToGarage")};
		EingangsraumFromOnPlane.conversationAnswers =
		EingangsraumFromLandedPlane.conversationAnswers =
		EingangsraumFromYourRoom.conversationAnswers =
		EingangsraumFromLab.conversationAnswers =
		EingangsraumFromGarage.conversationAnswers = EingangsroomAnswers;


		List<ConversationAnswer> YourRoomAnswers = new(){new(YourRoomFromSleeping, "Sleep"),
														 new(YourRoomFromLookingForEquipmentFail, "LookForEquipment", () => MyConditions[Conditions.Archive] == true && MyConditions[Conditions.LookedForAusrustung] == false, () => MyConditions[Conditions.LookedForAusrustung] = true),
														 new(YourRoomFromLookingForEquipmentSuccess, "LookForEquipment", () => MyConditions[Conditions.Archive] == false && MyConditions[Conditions.LookedForAusrustung] == false, () => MyConditions[Conditions.LookedForAusrustung] = true),
														 new(EingangsraumFromYourRoom, "GoBack")};
		YourRoomFromEingangsraum.conversationAnswers =
		YourRoomFromSleeping.conversationAnswers =
		YourRoomFromLookingForEquipmentFail.conversationAnswers =
		YourRoomFromLookingForEquipmentSuccess.conversationAnswers = YourRoomAnswers;



		List<ConversationAnswer> LabAnswers = new(){ new(LabFromArchive, "LookAround",() => MyConditions[Conditions.Archive] == false, () => {MyConditions[Conditions.Archive] = true; Debug.Log("ConditionSet"); }),
													 new(LabFromIceBearStudy, "StudyIcebears", () => MyConditions[Conditions.Archive] == true),
													 new(LabFromAnalyzeData, "AnalyzeData", selectFunc: () => MyConditions[Conditions.DataAnalyzed] = true),
													 new(LabFromInspectIceSample, "InspectIceSample", () => MyConditions[Conditions.FoundAusruestung] == true, () => MyConditions[Conditions.IceSampleInspected] = true),
													 new(EingangsraumFromLab, "GoBack")};
		LabFromEingangsraum.conversationAnswers =
		LabFromArchive.conversationAnswers =
		LabFromIceBearStudy.conversationAnswers =
		LabFromAnalyzeData.conversationAnswers =
		LabFromInspectIceSample.conversationAnswers = LabAnswers;


		GarageFromEingangsraum.conversationAnswers.Add(new(OnTheWayFromGarage, "StartExpedition", () => MyConditions[Conditions.Archive] == true && (MyConditions[Conditions.LostAusruestung] == true || MyConditions[Conditions.IceSampleInspected] == true)));
		GarageFromEingangsraum.conversationAnswers.Add(new(EingangsraumFromGarage, "GoBack"));


		List<ConversationAnswer> OnTheWayAnswers = new(){new(BabyIceBearFromOnTheWay, "SearchForIceBears"),
														 new(OnGlacierFromOnTheWayMustBeExploded, "GetToGlacier", () => MyConditions[Conditions.IceSampleInspected] ^ MyConditions[Conditions.DataAnalyzed]),
														 new(OnGlacierFromOnTheWayWeWillSee, "GetToGlacier", () => MyConditions[Conditions.IceSampleInspected] && MyConditions[Conditions.DataAnalyzed]),
														 new(OnGlacierFromOnTheWayWillCollapse, "GetToGlacier", () => MyConditions[Conditions.IceSampleInspected] == false && MyConditions[Conditions.DataAnalyzed] == false)};
		OnTheWayFromGarage.conversationAnswers =
		OnTheWayFromBabyIceBear.conversationAnswers = OnTheWayAnswers;

		List<ConversationAnswer> BabyIceBearAnswers = new(){new(OnTheWayFromBabyIceBear, "GetBackOnTrack"),
															new(BabyIceBearFromTakePicture, "TakePicture"),
															new(KilledByMamaFromBabyIceBear, "WalkCloser")};


		BabyIceBearFromOnTheWay.conversationAnswers =
		BabyIceBearFromTakePicture.conversationAnswers = BabyIceBearAnswers;

		OnGlacierFromOnTheWayMustBeExploded.conversationAnswers.Add(new(GlacierExplodedNode, "ExplodeGlacier"));

		OnGlacierFromOnTheWayWeWillSee.conversationAnswers.Add(new(GlacierWeWillSeeNode, "WeWillSee"));

		OnGlacierFromOnTheWayWillCollapse.conversationAnswers.Add(new(GlacierCollapsedNode, "GlacierWillCollapse"));


		return OnPlaneStart;
	}
}