using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{

	public float maxManaWidth;
	public float maxWizardHealthWidth;
	public float maxFamiliarHealthWidth;
	public Rect manaNominal = new Rect();
	public Rect wHealthNominal = new Rect();
	public Rect fHealthNominal = new Rect();

	public float maxMana;
	public float maxWizardHealth;
	public float maxFamiliarHealth;

	public GameObject wizard;
	public GameObject familiar;

	private GameObject manaMask;
	private GameObject wHealthMask;
	private GameObject fHealthMask;

	public Component c;

	private bool firstPass = true;

	// Use this for initialization
	void Start()
	{

		manaMask = GameObject.Find("ManaMask");
		wHealthMask = GameObject.Find("WizardHealthMask");
		fHealthMask = GameObject.Find("FamiliarHealthMask");

		manaNominal = manaMask.GetComponent<RectTransform>().rect;
		wHealthNominal = wHealthMask.GetComponent<RectTransform>().rect;
		fHealthNominal = fHealthMask.GetComponent<RectTransform>().rect;

	}

	// Update is called once per fram
	void Update()
	{

		wizard = GameObject.Find("Wizard");
		familiar = GameObject.Find("Familiar");

		// Don't bother is wizard wasn't found
		if (wizard == null)
		{
			//Debug.LogWarning("Failed to find Wizard");
			return;
		}

		if (firstPass)
		{

			maxMana = wizard.GetComponent<WizardShooting>().manaPool;
			maxWizardHealth = wizard.GetComponent<CollisionDamage>().health;
			maxFamiliarHealth = familiar.GetComponent<CollisionDamage>().health;

			firstPass = false;
		}

		float manaRatio = wizard.GetComponent<WizardShooting>().manaPool / maxMana;
		float wHealthRatio = wizard.GetComponent<CollisionDamage>().health / maxWizardHealth;

		manaMask.GetComponent<RectTransform>().sizeDelta = new Vector2(manaRatio * manaNominal.width, manaNominal.height);
		wHealthMask.GetComponent<RectTransform>().sizeDelta = new Vector2(wHealthRatio * wHealthNominal.width, wHealthNominal.height);

		if (familiar != null)
		{
			float fHealthRatio = familiar.GetComponent<CollisionDamage>().health / maxFamiliarHealth;
			fHealthMask.GetComponent<RectTransform>().sizeDelta = new Vector2(fHealthRatio * fHealthNominal.width, fHealthNominal.height);

		}

	}

}

