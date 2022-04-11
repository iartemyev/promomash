import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ContentComponent } from './content.component';
import { ContentRoutingModule } from './content-routing.module';
import { NotFoundComponent } from './not-found/not-found.component';

@NgModule({
	declarations: [ContentComponent, NotFoundComponent],
	imports: [ContentRoutingModule, CommonModule],
})
export class ContentModule {}
