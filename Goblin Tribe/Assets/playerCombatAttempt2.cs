using UnityEngine;

public class playerCombatAttempt2 : MonoBehaviour
{
    // game objects that belong to this layer will take damage
    public LayerMask enemyLayers;
    
    // attacks in attack string
    public GameObject attack1;
    public GameObject attack2;
    public GameObject attack3;

    // timing between attacks
    private float attackLength = 0.1f;
    private float lastClicked;
    private int comboLength = 0;
    float comboLimit = 0.4f;
    float comboCD = 0.1f;
    float lastComboEnded;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && Time.time - lastComboEnded > comboCD) {
            attack();
        }
        if (lastClicked >= attackLength)
        {
            if (comboLength == 0) { attack1.SetActive(false); }
            if (comboLength == 1) {
                attack1.SetActive(false);
                attack2.SetActive(false); 
            }
            if (comboLength >= 2) {
                attack1.SetActive(false);
                attack2.SetActive(false);
                attack3.SetActive(false); }
            }
        if (lastClicked >= comboLimit)
        {
            comboLength = 0;
        }
            lastClicked += Time.deltaTime;
    }

    void attack() {
        // Set up attack and transition 1 -> 3
        lastClicked = 0f;
        if (comboLength == 0) {
            attack1.SetActive(true);
            Debug.Log("Attack 1");
        }
        if (comboLength == 1) {
            attack2.SetActive(true);
            Debug.Log("Attack 2");
        }
        if (comboLength == 2)
        {
            attack3.SetActive(true);
            Debug.Log("Attack 3");
            comboLength = 2;
        }
        comboLength++;
        
        lastComboEnded = Time.time;

        // Detect enemies in hurt box
        //Collider2D[] hitEnemies = 

        // Damage enemies if in hurt box
        //foreach
    }
}
