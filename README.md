# Cat Survival - 숙련 프로젝트

</br>

## 팀원 : 임종운, 박기혁, 장지후, 조성우, 하승권, 천유진

> Unity 3D 서바이벌 게임 프로젝트 입니다.
> 주인공은 고양이 입니다.
> 비행기를 타고 가다가 무인도에 추락하여 비행기를 수리하고 무인도를 탈출하는 스토리입니다.
> 개발 기간은 4일이며, 구현된 내용은 다음과 같습니다.


</br>

# 필수 구현 사항
* 자원 수집 및 가공
* 건축 및 생존 기지 구축

![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/5bf08463-bf6f-400e-af28-a970d7f1fec3)

![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/28733f59-d012-4fd4-b63b-98c0f56e58a0)

![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/3472724a-3950-450f-95ab-ea38454fda1b)



R키를 누르면 도구와 가구를 제작할 수 있는 CraftingCanvas가 나타납니다. 제작하고 싶은 물품을 클릭하면 필요한 재료를 확인할 수 있습니다.


</br>

* 식사와 수분 관리
* 생존 관리 시스템


![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/dd647fb8-cab8-470c-8342-970decefb379)

플레이어의 컨디션은 배고픔, 수분, 스태미나, 체력, 체온 등이 있습니다.
낚싯대를 활용하여 물고기를 잡고 물고기를 잡거나 사냥으로 고기를 얻어 체력을 회복하고 배고픔을 달랠 수 있습니다.

![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/1f008c19-c696-492d-9b86-f19e34f45747)

강이나 바다에 가서 수분을 섭취할 수 있습니다.


</br>

* 적과의 전투

  
![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/cfb94c3a-0dac-421d-b1a7-5e878b17e878)
![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/be3caf79-42ad-4881-bfe3-c9bf9efbc9be)

강력한 적을 처치하면 비행기를 수리할 수 있는 재료를 얻을 수 있습니다.


  
</br>

* 자원 리스폰   
ResourceSpawner가 랜덤한 위치에 자원(나무)을 재생성합니다.

초기 화면

![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/3555729a-1f0f-41a3-8a24-7722f101c285)

자원이 랜덤으로 생성된 화면

![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/b95fb0de-1901-47a0-8790-312f97f6e1a2)


</br>

# 선택 구현 사항

* 날씨와 환경 요소

5월3일의 온도는 24.8도로 캐릭터의 온도에 영향을 많이 주지 않음

![12345](https://github.com/Stevejobjong/CatSurvival/assets/145965718/98a1396f-b69f-4321-baf0-1b42cbb9e68c)

2월3일의 온도는 -2.7도로 플레이어의 온도에 영향을 많이 주면서 낮은 온도로 인한 플레이어의 체력 감소

![123](https://github.com/Stevejobjong/CatSurvival/assets/145965718/aeece087-e6be-4507-b7e3-d54455d9c32d)

비가 오면 월드 온도가 5도 줄어듬

![1234](https://github.com/Stevejobjong/CatSurvival/assets/145965718/72d2462a-e490-42d9-833c-43b63ef97726)


  
* 다양한 적 종류

![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/44b6afb3-eb2e-4833-bd32-dd34d7282e1f)
![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/794c3045-e3f6-4372-a7cc-49250eaa1151)
![image](https://github.com/Stevejobjong/CatSurvival/assets/58843907/05079afc-fe6e-4009-8aa2-686eb1806e07)




* 퀘스트와 스토리   
  * 퀘스트창의 퀘스트를 통해 플레이어가 게임의 조작법에 적응 할 수 있습니다.   
![image](https://github.com/Stevejobjong/CatSurvival/assets/128495083/964ddcb8-277a-4687-b1a1-708c592c807d)

  * 플레이어가 자연스럽게 스토리를 이해할 수 있도록 퀘스트를 구성했습니다.   
![image](https://github.com/Stevejobjong/CatSurvival/assets/128495083/5d0af7b7-9828-4148-a5da-b137952ccae9)

* 사운드 및 음악
