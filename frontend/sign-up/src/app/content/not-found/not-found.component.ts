import { Component, OnInit } from '@angular/core';
import { LoggerService } from '../../shared/service/logger.service';

@Component({
	selector: 'app-not-found',
	templateUrl: './not-found.component.html',
})
export class NotFoundComponent implements OnInit {
	public constructor(private _logger: LoggerService) {}

	public ngOnInit(): void {
		this._logger.info('NotFoundComponent ngOnInit');
	}
}
