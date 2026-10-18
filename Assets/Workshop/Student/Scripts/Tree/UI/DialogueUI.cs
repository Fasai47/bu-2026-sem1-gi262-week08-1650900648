using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueUI : MonoBehaviour
{
    [Header("UI References")]
    public GameObject dialoguePanel;
    public TextMeshProUGUI npcText;
    public Transform choiceContainer;
    public Button choiceButtonPrefab; // ลาก Prefab ปุ่มตัวเลือกมาใส่
    public GameObject closeButtonDialogue;
    private DialogueSequen InteractNpcSequen;

    // เก็บปุ่มที่ถูกสร้างขึ้น เพื่อนำไปทำลาย/ซ่อนในภายหลัง
    private List<Button> activeButtons = new List<Button>();

    public void Setup(DialogueSequen sequen)
    {
        // 1. Set Dialogue Sequen
        InteractNpcSequen = sequen;

        // Show UI
        if (dialoguePanel != null) dialoguePanel.SetActive(true);
        gameObject.SetActive(true);
        if (closeButtonDialogue != null) closeButtonDialogue.SetActive(false);
    }

    public void ShowDialogue(DialogueNode node)
    {
        if (node == null) return;

        // 2. set ให้เป็น โหนดปัจจุบัน
        // (หากใน DialogueSequen มีตัวแปรเก็บ currentNode สามารถอัปเดตได้ที่นี่)

        // 3. แสดงข้อความของ NPC
        npcText.text = node.text; // หมายเหตุ: หากใน DialogueNode ใช้ชื่อตัวแปรอื่น เช่น node.dialogueText ให้เปลี่ยนตามคลาสจริง

        // 4. ล้างปุ่มตัวเลือกเก่า
        ClearChoices();

        // 5. สร้างปุ่มตัวเลือกใหม่ตาม nexts
        if (node.nexts != null)
        {
            for (int i = 0; i < node.nexts.Count; i++) // หรือ node.nexts.Length หากเป็น Array
            {
                // ดึงข้อความของตัวเลือกแต่ละข้อออกมาก่อสร้างปุ่ม
                string choiceText = node.nexts[i].text; // หาก nexts เก็บออบเจกต์ที่มีชื่อตัวแปรอื่น ให้ปรับตามจริง
                CreateChoiceButton(choiceText, i);
            }
        }
    }

    private void CreateChoiceButton(string text, int index)
    {
        Button newButton = Instantiate(choiceButtonPrefab, choiceContainer);

        // ตั้งค่าข้อความบนปุ่ม
        newButton.GetComponentInChildren<TextMeshProUGUI>().text = text;

        // เพิ่ม Listener เมื่อกดปุ่ม
        // ใช้ Lambda Expression เพื่อส่ง index กลับไปให้ DialogueManager
        newButton.onClick.AddListener(() => OnChoiceSelected(index));

        activeButtons.Add(newButton);
    }

    private void ClearChoices()
    {
        foreach (Button button in activeButtons)
        {
            Destroy(button.gameObject);
        }
        activeButtons.Clear();
    }

    private void OnChoiceSelected(int index)
    {
        // ส่ง index ของตัวเลือกที่ผู้เล่นเลือกกลับไปให้ DialogueManager จัดการ
        InteractNpcSequen.SelectChoice(index);
    }

    public void ShowCloseButtonDialog() 
    {
        closeButtonDialogue.gameObject.SetActive(true);
    }

    public void HideDialogue()
    {
        dialoguePanel.SetActive(false);
        ClearChoices();
    }
}
