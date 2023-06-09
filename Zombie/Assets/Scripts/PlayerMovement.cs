﻿using UnityEngine;

// 플레이어 캐릭터를 사용자 입력에 따라 움직이는 스크립트
public class PlayerMovement : MonoBehaviour {
    public float moveSpeed = 5f; // 앞뒤 움직임의 속도
    public float rotateSpeed = 180f; // 좌우 회전 속도


    private PlayerInput playerInput; // 플레이어 입력을 알려주는 컴포넌트
    private Rigidbody playerRigidbody; // 플레이어 캐릭터의 리지드바디
    private Animator playerAnimator; // 플레이어 캐릭터의 애니메이터

    private void Start() {
        // 사용할 컴포넌트들의 참조를 가져오기
        playerInput = GetComponent<PlayerInput>();
        playerRigidbody = GetComponent<Rigidbody>();
        playerAnimator = GetComponent<Animator>();
    }

    // FixedUpdate는 물리 갱신 주기<기본값 0.02초>에 맞춰 실행됨   [갱신 주기 = Time.fixedDeltaTime]
    private void FixedUpdate() {
        // 물리 갱신 주기마다 움직임, 회전, 애니메이션 처리 실행

        // 회전 실행
        Rotate();
        // 움직임 실행
        Move();

        // 입력값에 따라 애니메이터의 Move 파라미터값 변경
        // Move 파라미터는 애니메이터의 Movement 상태의 Blend Tree에서 사용
        // 사용자 입력에 따라 걷고 뛰는 애니메이션이 자연스럽게 변경
      
        playerAnimator.SetFloat("Move", playerInput.move);      
    }

    // 입력값에 따라 캐릭터를 앞뒤로 움직임
    private void Move() {
        // 상대적으로 이동할 거리 계산 (한 프레임 동안 현재 위치에서 상대적으로 더 이동할 거리 + 방향)
        Vector3 moveDistance =
            playerInput.move * transform.forward * moveSpeed * Time.deltaTime;
        // 사용자 입력(앞쪽 방향) * 속력 * 시간

        // 리지드바디를 이용해 게임 오브젝트 위치 변경
        playerRigidbody.MovePosition(playerRigidbody.position + moveDistance);
    }

    // 입력값에 따라 캐릭터를 좌우로 회전
    private void Rotate() {
        // 상대적으로 회전할 수치 계산
        float turn = playerInput.rotate * rotateSpeed * Time.deltaTime;
        // 사용자 입력 * 회전 속도 * 시간

        // 리지드바디를 이용해 게임 오브젝트 회전 변경
        playerRigidbody.rotation =
            playerRigidbody.rotation * Quaternion.Euler(0, turn, 0f);       // turn만큼 y축 회전
    }
}