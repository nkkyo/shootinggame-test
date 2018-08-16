using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace NaruDesign
{

    public class warning : MonoBehaviour
    {
        Rigidbody2D rigid2d;
        RectTransform rect;
        Text text;
        public bool a=false;
        Color b;
        public float speed;
        public float movespeed;

        private void Start()
        {
            rigid2d = GetComponent<Rigidbody2D>();
            rect = GetComponent<RectTransform>();
            text = GetComponent<Text>();
           
        }

        private void Update()
        {
          //  text.color = new Color((text.color.r - speed/255f),
            //    (text.color.g - speed/255f), (text.color.b - speed/255f));

             if (text.color.b >= 190/255f) a = false;
              if (text.color.b <= 90/255f) a = true;

              if (!a) text.color = new Color((text.color.r - speed / 255f),
               (text.color.g - speed / 255f), (text.color.b - speed / 255f));

            else text.color = new Color((text.color.r + speed / 255f),
               (text.color.g + speed / 255f), (text.color.b + speed / 255f));

          //  rect.position = rect.position + new Vector3(5, 0, 0);

      
        }
    }
      
}