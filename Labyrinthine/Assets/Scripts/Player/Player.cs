using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement movement { get; set; }
    public EngineBehaviour engine { get; set; }
    private GameManager manager;
    private bool takenDamage;
    private float timeStorage;
    private bool startInTimer;
    private float timerForInDanger;

    [SerializeField] float shieldTimer;
    [SerializeField] float timeInDangerToTakeDamage;
    [SerializeField] private float hazardHeatDamage = 5.0f;
    [SerializeField] private float dangerZoneHeatDamage = 10.0f;
    [SerializeField] private float coolantAmount = 1.0f;
    [SerializeField] ScreenShake shake;
    [SerializeField] GameObject vehicle;
    [SerializeField] FadeImage coolant;
    [SerializeField] FadeImage hazard;
    // Update is called once per frame
    void Start()
    {
        startInTimer = false;
        takenDamage = false;
        timeStorage = shieldTimer;
        movement = this.gameObject.GetComponent<PlayerMovement>();
        engine = this.gameObject.GetComponent<EngineBehaviour>();
        manager = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameManager>();
    }
    private void FixedUpdate()
    {
		if(takenDamage)
		{
			shieldTimer -= Time.fixedDeltaTime;
			if(shieldTimer <= 0.0f)
			{
				takenDamage = false;
				shieldTimer = timeStorage;
			}
		}
		if(startInTimer && !takenDamage)
		{
			timerForInDanger += Time.fixedDeltaTime;
			if (timerForInDanger >= timeInDangerToTakeDamage)
			{
				takenDamage = true;
				engine.engineHeatAmount += dangerZoneHeatDamage;
				hazard.flash = true;
				timerForInDanger = 0;
			}
		}
        if(takenDamage)
        {
            vehicle.gameObject.SetActive(!vehicle.activeSelf);
        }
        if (!takenDamage && vehicle.gameObject.activeSelf == false)
        {
            vehicle.gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Hazard")
        {
            if (!takenDamage)
            {
                //Adds the heat to the engine
                engine.engineHeatAmount += hazardHeatDamage;
                //Shakes your screen
                shake.shake = true;
                //Enables a little shield
                takenDamage = true;
				hazard.flash = true;
            }
        }
        if(other.tag == "Note")
        {
            //Adds to the combo counter
            manager.comboScore += 1;
            //Adds to the total score
            manager.AddScore(10.0f);
            //Flashes the blue color over the gauge
            coolant.flash = true;
            //Cools the engine
            engine.CoolEngineByAmount(coolantAmount);
            //Starts the animation for the note collection
            other.GetComponent<Note>().Collected();
        }
        if (other.tag == "END")
        {
            //Stops the game
            Time.timeScale = 0.0f;
        }
        if(other.tag == "DangerZone")
        {
                //Starts a timer for the duration that you are inside the danger zone
                startInTimer = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "DangerZone")
        {
            //Stops the timer for the time inside the danger zone
            startInTimer = false;
            //Resets the timer
            timerForInDanger = 0.0f;
        }
    }
}
