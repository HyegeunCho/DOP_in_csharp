# DOP_in_csharp
Data oriented programming in c#

데이터 주도 프로그래밍을 학습하고 주요 개념을 C#으로 구현하여 유니티 프로젝트에서 사용하기 위한 저장소입니다.

참고서적: [Data-Oriented Programming](https://www.manning.com/books/data-oriented-programming)

# DOP 규칙
1. 코드와 데이터를 분리한다.
2. 데이터 엔티티를 제너릭 데이터 구조체로 표현한다.

# 데이터 표현
데이터는 Heterogeneous string map 으로 저장합니다.

>문자열을 키로 갖는 서로 다른 타입의 데이터를 저장할 수 있는 Hashmap 구조체를 의미합니다.

```cs
DataMap watchmen = DataMap.Create(
    DataMap.MapOf(
        "isbn", "978-1779501127",
        "title", "Watchmen",
        "publicationYear", 1987,
        "authors", DataMap.ListOf("alan-moore", "dave-gibbons"),
        "bookItems", DataMap.ListOf(
            DataMap.MapOf(
                "id", "book-item-1",
                "libId", "nyc-central-lib",
                "isLent", true
            ), 
            DataMap.MapOf(
                "id", "book-item-2",
                "libId", "nyc-central-lib",
                "isLent", false
            )
        ), 
        "reviews", DataMap.MapOf(
            "reader1", "Interesting", 
            "me", "5 for 5!"
        )
    )    
);
```

Map에 저장된 데이터를 읽을 때는 경로로 읽는다.

```cs
watchmen.GetData("reviews", "reader1");
```

## 클래스 멤버 접근 vs Map 접근

Map으로 접근 시 클래스 멤버로 접근할 때에 비해 성능 상으로 조금 더 느릴 수 있으니 유의미한 차이가 있진 않다. 
최근의 프로그래밍 언어들은 Map을 충분히 빠르게 사용하고 있다.

만약 클래스 오브젝트로 표현된 데이터를 획득하려고 한다면 데이터 경로를 특정 코드 형식으로 표현해야 한다.

```cs
watchmen.reviews[0].review;
```

Map으로 데이터에 접근할 경우의 이점은 Generic 함수로 데이터를 획득할 수 있다는 점이다.
```cs
watchmen.GetData("reviews", "reader1");
```

또한 데이터 경로 정보 자체를 1급 객체로써 활용할 수 있다. - 임시로 저장한다거나 다른 함수에 파라미터로 전달할 수 있다.





