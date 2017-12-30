import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";
import { RouterModule, Routes } from "@angular/router";

import { AppComponent } from "./components/app/app.component";
import { HomeComponent } from "./components/home/home.component";
import { NavComponent } from "./components/nav/nav.component";
import { ProductsModule } from "./products/products.module";
import { AnimalModule } from "./animals/animal.module";

const routes: Routes = [
  {
    path: "home",
    component: HomeComponent
  },
  {
    path: "",
    redirectTo: "home",
    pathMatch: "full"
  }
];

@NgModule({
  declarations: [AppComponent, HomeComponent, NavComponent],
  imports: [
    CommonModule,
    ProductsModule,
    AnimalModule,
    HttpModule,
    FormsModule,
    RouterModule.forRoot(routes)
  ]
})
export class AppModuleShared {}
