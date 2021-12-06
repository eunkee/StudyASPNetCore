# Sutdy ASP.NET CORE
### Inflearn Class: 14일만에 배우는 ASP.NET CORE
### https://www.inflearn.com/course/%EB%8B%B7%EB%84%B7-%EC%BD%94%EC%96%B4/dashboard

<br/><br/>
### 1. ASP.NET CORE 개요
---
### 03. MVC 패턴


`[ValidateAntiForgeryToken]`: 위조방지토큰을 통해 View로 부터 받은 Post data가 유효한지 검증합니다.

`End User` => `Controller`에게 요청

`Controller` => `End User`에게 응답

`View` => 응답 결과를 화면으로 출력

`Model` => `End User`로부터 `Controller`을 거쳐 `View`까지 `Data`이동

---

### 04. 의존성 주입

`Views > Shared > menu` navi-item 수정 가능

**서비스 프로젝트 구성**

1. 서비스의 재사용성

2. 모듈화를 통한 효율적 관리


`ViewImpoerts.cshtml`: Web 프로젝트 전체적으로 View들에 사용될 using 참조문을 관리하는 파일

=> 이 곳에서 ViewModel의 Namespace 지정


`Startup.cs ConfigureServices`에서 인터페이스에 서비스 클래스 인스턴스를 주입


`MCV`는 각자가 맡은 역할을 다할 수 있도록 `분리` 되어 있다.

`의존성 주입`도 클래스 인스턴스를 직접 받지 않고 생성자의 파라미터를 통해 주입받아 사용한다.

닷넷코어의 키워드는 `분리`이다.

---
