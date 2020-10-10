using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI countText;

    private Action OnCountMax;

    public int max;
    public int current;

    private void Start() {
        this.countText.text = "";
    }

    public void StartCount(int max) {
        this.current = 0;
        this.max = max;
        this.countText.text = this.current.ToString() + "/" + this.max.ToString();
    }

    public void SetCountText() {
        this.current += 1;
        this.countText.text = this.current.ToString() + "/" + this.max.ToString();
        if (this.current == this.max) {
            this.OnCountMax?.Invoke();
        }
    }

    public void init(Action OnCountMaxHandler) {
        this.OnCountMax = OnCountMaxHandler;
    }
}
