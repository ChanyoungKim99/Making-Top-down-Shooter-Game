using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/GunData", fileName = "Gun Data")]
// 특성 : 어떤 클래스나 메서드, 변수 등에 대한 추가정보를 제공하는 C# 문법
// 사용할 특성 이름을 대괄호 [] 로 묶고, 필요에 따라 추가 값을 전달합니다.
// CreateAssetMenu 특성은 해당 타입의 에셋을 생성할 수 있는 버튼을 Assets와 Create 메뉴에 추가
// [CreateAssetMenu(menuName = "메뉴 경로", filename = "기본 파일명", order = 메뉴 상에서 순서)]

public class GunData : ScriptableObject         // 스크립터블 오브젝트로 동작하도록 ScriptableObject 클래스 상속
{
    public AudioClip shotClip; // 발사 소리
    public AudioClip reloadClip; // 재장전 소리

    public float damage = 25; // 공격력

    public int startAmmoRemain = 100; // 처음에 주어질 전체 탄약
    public int magCapacity = 25; // 탄창 용량

    public float timeBetFire = 0.12f; // 총알 발사 간격
    public float reloadTime = 1.8f; // 재장전 소요 시간
}