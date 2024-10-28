import { Routes } from '@angular/router';
import { FirstComponent } from './first/first.component';
import { SecondComponent } from './second/second.component';
import { ThirdComponent } from './third/third.component';
import { PageNotFounrComponent } from './page-not-founr/page-not-founr.component';
import { ChildAComponent } from './first/child-a/child-a.component';
import { ChildBComponent } from './first/child-b/child-b.component';
import { ListComponent } from './list/list.component';
import { AddNewComponent } from './add-new/add-new.component';
import { DeleteComponent } from './delete/delete.component';
import { DetailsComponent } from './details/details.component';
import { UpdateComponent } from './update/update.component';
import { HomeComponent } from './home/home.component';
export const routes: Routes = [
  { path: '', redirectTo: '/', pathMatch: 'full' },
  {path:'list',component:ListComponent},
  {path:'addNew',component:AddNewComponent},
  {path:'delete',component:DeleteComponent},
  {path:'details',component:DetailsComponent},
  {path:'update',component:UpdateComponent},
  {path:'home',component:HomeComponent},

    // {
    //     path: '',
    //     component: FirstComponent,
    //     children: [
    //       { path: '', redirectTo: 'child-a', pathMatch: 'full' },
    //       { path: 'child-a', component: ChildAComponent },
    //       {path:'child-b',component:ChildBComponent},
    //     ],
    //   },
//   {
//     path: 'first-component',
//     component: FirstComponent,
//     children: [
//       { path: '', redirectTo: 'child-a', pathMatch: 'full' },
//       { path: 'child-a', component: ChildAComponent },
//       {path:'child-b',component:ChildBComponent},
//     ],
//   },
//   { path: 'second-component', component: SecondComponent },
//   { path: 'third-component', component: ThirdComponent },
  { path: '**', component: PageNotFounrComponent },
];
