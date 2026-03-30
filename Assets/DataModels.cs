using System;
using System.Collections.Generic;

// Class는 뭘까요?
// 모든 클래스는 틀이고, 이걸 메모리에 실제 저장해야 데이터 혹은 함수로 작동을 한다. (Static같은 특수한 경우가 있기는ㄴ 한데...)
// 유환진 RankData
// 동준 RankData
// 제현 RankData
// 단순 데이터 저장 -> Struct
// 클래스는 내부 함수를 넣고, 상속이 가능
// Struct는 그냥 변수만 들고 있음

public class RankData
{
    public string Savedname = "AAA";
    public int Savedscore = 0;
}

// [과제 요구사항 15] 세이브 데이터 구조
[Serializable]
public class SaveData
{
    public float money;
    public int stage;
    public float playerHp;

    // 파츠 정보 저장을 위한 리스트
    public List<PartSaveInfo> partStates = new List<PartSaveInfo>();

    // 현재 퀵슬롯 장착 상태
    public PartType leftSlotPart;
    public PartType rightSlotPart;
}

[Serializable]
public class PartSaveInfo
{
    public PartType type;
    public PartState state;
}