using UnityEngine;
using UnityEngine.UI;
public class EnemyHealthBarEngine : MonoBehaviour
{
    public Image filledimg;
    float reduceamount;
    // Start is called before the first frame update
    void Start()
    {
        filledimg.fillAmount = 1f;
        if (transform.tag == "Vampire")
            reduceamount = 0.2f;
        else if (transform.tag == "Mutant")
            reduceamount = 0.1f;
    }
    public void ReduceHP()
    {
        filledimg.fillAmount -= reduceamount;
        if (filledimg.fillAmount == 0)
            print("I'm Dead");
    }
}
