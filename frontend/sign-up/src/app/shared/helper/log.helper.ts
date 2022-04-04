export class LogHelper {
	public static pretty(value: any): string {
		return JSON.stringify(value, null, 2);
	}
}
