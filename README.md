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

### 04. 의존성 주입 패턴

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
<br/><br/>

### 2. Entity Framework Core
---
### 05. Entity Framework Core 소개

① Code-First

코드작성 우선주의

Migrations : 미리 작성된 코드로 데이터베이스에 테이블과 컬럼 작성

② Database-First

데이터베이스 작업 우선주의

Entity Data Modeling: 코드를 쉽게 작성할 수 있도록 도와줌.

<br/><br/>

### 07. Code-First 방식

장점: 1. Table과 Column을 Application에서 관리 2. Migrations를 통한 이력 관리

단점: 2. 사소한 작업을 Migrations하는 것이 번거로움 2. 운영서버에 바로 적용이 어려움

### 08. Database-First 방식

장점: 1. Database작업은 기존과 동일하게 수행 가능 2. Entity Data Modelling으로 손 코딩 거의 없음

단점: 2. Database 작업의 이력관리를 하지 못함 2. Table 또는 Column 변경 시 C#코드도 수동 변경

---
