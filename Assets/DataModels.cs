using System;
using System.Collections.Generic;

// 랭킹 데이터 단위
[Serializable]
public class RankData
{
    public string name;
    public int score;
}

// 랭킹 리스트 (JSON 변환용)
[Serializable]
public class RankList
{
    public List<RankData> ranks = new List<RankData>();
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