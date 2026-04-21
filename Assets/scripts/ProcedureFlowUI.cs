using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ProcedureFlowUI : MonoBehaviour
{
    [Header("Panels")]
    public GameObject menuPanel;
    public GameObject stepsListPanel;
    public GameObject stepPlayerPanel;

    [Header("Steps List UI")]
    public TMP_Text stepsListTitle;
    public TMP_Text stepsListText;

    [Header("Step Player UI")]
    public TMP_Text playerTitle;
    public TMP_Text stepCount;
    public TMP_Text stepDescription;
    public Image stepImage; // optional

    public Button nextBtn;
    public Button backBtn;

    // -------- STEP TITLES (LIST VIEW) --------
    private string[] woundStepTitles = new string[8]
    {
        "Gather supplies",
        "Hand hygiene",
        "Prepare sterile field",
        "Remove old dressing",
        "Assess wound",
        "Clean wound",
        "Apply dressing",
        "Document and clean up"
    };

    private string[] catheterStepTitles = new string[8]
    {
        "Gather supplies",
        "Hand hygiene",
        "Prepare sterile field",
        "Clean perineal area",
        "Insert catheter",
        "Inflate balloon",
        "Secure catheter and connect bag",
        "Document and clean up"
    };

    private string[] imStepTitles = new string[8]
    {
        "Gather supplies",
        "Verify patient and explain",
        "Hand hygiene and gloves",
        "Choose site and position",
        "Clean skin",
        "Prepare medication",
        "Inject IM and dispose safely",
        "Document and monitor"
    };

    private string[] scStepTitles = new string[8]
    {
        "Gather supplies",
        "Verify patient and explain",
        "Hand hygiene and gloves",
        "Choose site and pinch skin",
        "Clean skin",
        "Prepare medication",
        "Inject subcutaneous and dispose",
        "Document and monitor"
    };

    private string[] ivStepTitles = new string[8]
    {
        "Gather supplies",
        "Verify patient and explain",
        "Hand hygiene and prep site",
        "Apply tourniquet and find vein",
        "Clean skin (aseptic)",
        "Insert IV catheter",
        "Secure IV and flush",
        "Document and monitor"
    };

    // -------- STEP DETAILS (STEP PLAYER) --------
    private string[] woundStepDetails = new string[8]
    {
        "Aseptic preparation: perform hand hygiene, don PPE, and maintain aseptic technique throughout the procedure.",
        "Gather all required wound care supplies and verify the patient using proper identification.",
        "Position the patient comfortably and expose only the wound area to maintain privacy.",
        "Carefully remove the old dressing using clean technique and dispose of it safely.",
        "Assess the wound for redness, drainage, odor, or signs of infection.",
        "Clean the wound using sterile solution from the center outward without contaminating the area.",
        "Apply prescribed medication (if ordered) and place a new sterile dressing using sterile technique.",
        "Dispose supplies, remove gloves, perform hand hygiene, and document wound care."
    };

    private string[] catheterStepDetails = new string[8]
    {
        "Aseptic preparation: perform hand hygiene, don sterile gloves, and maintain a sterile field.",
        "Gather catheterization supplies and explain the procedure to the patient.",
        "Position the patient appropriately and prepare a sterile field.",
        "Clean the perineal area using antiseptic swabs with sterile technique.",
        "Lubricate and insert the catheter without breaking aseptic technique.",
        "Advance the catheter until urine flow is observed.",
        "Inflate the balloon with sterile water and secure the catheter tubing.",
        "Position the drainage bag correctly, ensure patient comfort, and document the procedure."
    };

    // IM Injection (3 sentences each)
    private string[] imStepDetails = new string[8]
    {
        "Collect syringe, needle, medication vial, alcohol swabs, gauze, and a sharps container. Check the medication label and expiration date carefully. Keep everything ready within reach.",
        "Confirm the patient using proper identification and explain what you will do. Ask about allergies and check the medication order. Provide privacy and answer any questions briefly.",
        "Perform hand hygiene and put on clean gloves. Keep the injection area exposed only as needed. Maintain a clean technique throughout the steps.",
        "Select the correct IM site (like deltoid or vastus lateralis) and position the patient comfortably. Identify landmarks to avoid nerves and blood vessels. Make sure the muscle is relaxed.",
        "Clean the skin with an alcohol swab in a circular motion. Let the area air dry completely. Do not touch the cleaned site again.",
        "Prepare the medication using the correct dose and remove air bubbles. Change the needle if required after drawing from the vial. Keep the syringe sterile and ready.",
        "Insert the needle at about a 90-degree angle and inject the medication steadily. Withdraw the needle smoothly and apply gentle pressure with gauze. Dispose the needle immediately into the sharps container.",
        "Observe the patient for pain, bleeding, or any reaction. Provide simple aftercare instructions if needed. Document medication, dose, site, time, and patient response."
    };

    // Subcutaneous Injection (3 sentences each)
    private string[] scStepDetails = new string[8]
    {
        "Gather the medication, correct syringe/needle, alcohol swabs, gauze, and a sharps container. Verify the medication label and expiration date. Keep supplies organized and close by.",
        "Verify the patient and explain the injection in simple words. Check allergies and confirm the medication order and dose. Ensure the patient is comfortable and has privacy.",
        "Wash hands and put on clean gloves. Choose a clean working area and keep the syringe protected. Follow clean technique for the procedure.",
        "Choose an appropriate site (like abdomen or outer upper arm) and gently pinch the skin. Avoid bruised, scarred, or irritated areas. Keep the skin pinch steady.",
        "Clean the injection site with an alcohol swab and allow it to air dry. Do not blow on it or wipe it dry. Avoid touching the area after cleaning.",
        "Prepare the correct dose and remove air bubbles if needed. Confirm the medication amount one more time before injecting. Hold the syringe like a pencil for control.",
        "Insert the needle at about 45–90 degrees depending on needle length and patient tissue. Inject slowly, then remove the needle and release the pinch. Dispose the needle safely in a sharps container and apply gentle pressure if needed.",
        "Monitor for bleeding, swelling, or an allergic reaction. Provide basic instructions, like not rubbing the site if advised. Document the medication, dose, site, time, and patient response."
    };

    // IV Catheter Insertion (3 sentences each)
    private string[] ivStepDetails = new string[8]
    {
        "Gather IV catheter, tourniquet, antiseptic swabs (chlorhexidine/alcohol), gloves, tape/securement, flush, extension tubing, gauze, and sharps container. Check the order and choose appropriate catheter size. Prepare a clean workspace.",
        "Verify the patient and explain the IV insertion briefly. Ask about allergies (especially to antiseptics or adhesives). Position the patient comfortably with the arm supported.",
        "Perform hand hygiene and put on gloves. Inspect both arms and choose a suitable site. Prepare the skin and equipment before applying the tourniquet for too long.",
        "Apply the tourniquet above the site and locate a good vein by sight and touch. Ask the patient to relax their hand or gently lower the arm to help vein filling. Do not slap the vein; use gentle technique.",
        "Clean the site using aseptic technique and let it air dry fully. Do not touch the cleaned area again. If you touch it, you must clean again.",
        "Insert the catheter bevel-up at a shallow angle until you see flashback. Advance the catheter into the vein and remove the needle (stylet) safely. Activate the safety and dispose the needle in the sharps container.",
        "Release the tourniquet and connect extension tubing or cap, then flush to confirm patency. Secure the catheter with tape/securement and apply a dressing. Check for swelling or pain that could indicate infiltration.",
        "Ensure the patient is comfortable and the IV is flowing as ordered. Label the dressing with date/time if required. Document site, gauge, number of attempts, patient response, and any complications."
    };

    // -------- CURRENT SELECTION --------
    private string currentTitle;
    private string[] currentStepTitles;
    private string[] currentStepDetails;

    private int currentStepIndex = 0;

    void Start()
    {
        ShowMenu();
    }

    // -------- MENU (BUTTON FUNCTIONS) --------
    public void ChooseWoundCare()
    {
        currentTitle = "Wound Care";
        currentStepTitles = woundStepTitles;
        currentStepDetails = woundStepDetails;
        ShowStepsList();
    }

    public void ChooseCatheter()
    {
        currentTitle = "Urinary Catheterization";
        currentStepTitles = catheterStepTitles;
        currentStepDetails = catheterStepDetails;
        ShowStepsList();
    }

    public void ChooseIMInjection()
    {
        currentTitle = "Intramuscular (IM) Injection";
        currentStepTitles = imStepTitles;
        currentStepDetails = imStepDetails;
        ShowStepsList();
    }

    public void ChooseSubcutaneousInjection()
    {
        currentTitle = "Subcutaneous (SC) Injection";
        currentStepTitles = scStepTitles;
        currentStepDetails = scStepDetails;
        ShowStepsList();
    }

    public void ChooseIVCatheter()
    {
        currentTitle = "IV Catheter Insertion";
        currentStepTitles = ivStepTitles;
        currentStepDetails = ivStepDetails;
        ShowStepsList();
    }

    public void ShowMenu()
    {
        menuPanel.SetActive(true);
        stepsListPanel.SetActive(false);
        stepPlayerPanel.SetActive(false);
        currentStepIndex = 0;
    }

    // -------- STEPS LIST SCREEN --------
    void ShowStepsList()
    {
        menuPanel.SetActive(false);
        stepsListPanel.SetActive(true);
        stepPlayerPanel.SetActive(false);

        stepsListTitle.text = currentTitle;
        stepsListText.text = "";

        for (int i = 0; i < currentStepTitles.Length; i++)
        {
            stepsListText.text += $"{i + 1}. {currentStepTitles[i]}\n";
        }
    }

    public void BackFromListToMenu()
    {
        ShowMenu();
    }

    // -------- STEP PLAYER --------
    public void StartProcedure()
    {
        if (currentStepDetails == null || currentStepDetails.Length == 0)
            return;

        currentStepIndex = 0;
        ShowStepPlayer();
        RefreshStepPlayer();
    }

    void ShowStepPlayer()
    {
        menuPanel.SetActive(false);
        stepsListPanel.SetActive(false);
        stepPlayerPanel.SetActive(true);
    }

    void RefreshStepPlayer()
    {
        playerTitle.text = currentTitle;
        stepCount.text = $"Step {currentStepIndex + 1} / {currentStepDetails.Length}";
        stepDescription.text = currentStepDetails[currentStepIndex];

        if (stepImage != null)
            stepImage.gameObject.SetActive(false);

        backBtn.interactable = true;
        nextBtn.interactable = currentStepIndex < currentStepDetails.Length - 1;
    }

    // -------- BUTTON ACTIONS --------
    public void NextStep()
    {
        if (currentStepIndex < currentStepDetails.Length - 1)
        {
            currentStepIndex++;
            RefreshStepPlayer();
        }
    }

    public void PrevStep()
    {
        // If user presses Back on Step 1 → go back to steps list
        if (currentStepIndex == 0)
        {
            stepsListPanel.SetActive(true);
            stepPlayerPanel.SetActive(false);
            return;
        }

        currentStepIndex--;
        RefreshStepPlayer();
    }

    public void ExitToMenu()
    {
        ShowMenu();
    }
}
